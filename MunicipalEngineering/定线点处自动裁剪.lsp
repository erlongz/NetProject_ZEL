(defun c:szcj (/	angle_sz c1	  dist	   dx_cut   dx_lx
	       dx_obj	dx_szss	 i dxss	  j	   length_obj
	       point1	point2	 pt_list  sz_ent   sz_ins   w1
	       w2	x
	      )
  (setvar "osmode" 0)
  (setvar "cmdecho" 0)
  (command ".undo" "be")

  (setq dxss (ssget "x"'((0 . "*POLYLINE")
			   (8 . "定线")
			  )
		  )
      )
  (setq i 0)
  (if dxss
   (repeat (sslength dxss)
     (command "pedit" (ssname dxss i) "w" 0.5 "")
     (setq i (1+ i))
     )
    )

  
  (setq	dx_szss	(ssget "x"
		       '((0 . "INSERT")
			 (2 . "SZS")
			 (8 . "定线")
			)
		)
  )
  (setq i 0)
  (if dx_szss
    (repeat (sslength dx_szss)
      (setq pt_list '())
      (setq sz_ent (ssname dx_szss i))
      (setq sz_ins (cdr (assoc 10 (entget sz_ent))))
      (command "circle" sz_ins 1)
      (setq c1 (entlast))
      (setq w1 (polar sz_ins (* 1.25 pi) 10))
      (setq w2 (polar sz_ins (* 0.25 pi) 10))
      (command "zoom" "w" w1 w2)
      (setq dx_lx (ssget "C"
			 (polar sz_ins (* 1.25 pi) 1)
			 (polar	sz_ins
				(* 0.25 pi)
				1
			 )
			 '((0 . "*POLYLINE")
			   (8 . "定线")
			  )
		  )
      )
      (setq j 0)
      (if dx_lx
	(progn
	  (repeat (sslength dx_lx)
	    (setq dx_cut (list (ssname dx_lx j) sz_ins))


	    ;;
	    (setq dx_obj (vlax-ename->vla-object (ssname dx_lx j)))
	    (setq dist (vlax-curve-getDistAtPoint
			 dx_obj
			 (vlax-curve-getClosestPointTo dx_obj sz_ins)
		       )
	    )
	    (setq length_obj
		   (vlax-curve-getDistAtParam
		     dx_obj
		     (vlax-curve-getEndParam dx_obj)
		   )
	    )
	    (cond
	      ((= dist 0)
	       (setq point1 (vlax-curve-getPointAtDist dx_obj 0.2))
	       (setq pt_list (cons point1 pt_list))
	      )
	      ((equal dist length_obj 0.01)
	       (setq point1 (vlax-curve-getPointAtDist
			      dx_obj
			      (- length_obj 0.2)
			    )
	       )
	       (setq pt_list (cons point1 pt_list))
	      )
	      (t
	       (setq
		 point1	(vlax-curve-getPointAtDist
			  dx_obj
			  (+ 0.2
			     (vlax-curve-getDistAtPoint dx_obj (vlax-curve-getClosestPointTo dx_obj sz_ins))
			  )
			)
	       )
	       (setq
		 point2	(vlax-curve-getPointAtDist
			  dx_obj
			  (-
			    (vlax-curve-getDistAtPoint dx_obj (vlax-curve-getClosestPointTo dx_obj sz_ins))
			    0.2
			  )
			)
	       )
	       (setq pt_list (cons point1 pt_list))
	       (setq pt_list (cons point2 pt_list))
	      )
	    )



	    ;;
	    (command "trim" c1 "" dx_cut "")
	    (setq j (1+ j))
	  )
;;;
	  (setq pt_list (listremoveatom nil pt_list))
	  (setq	angle_sz (/ (apply '+
				   (mapcar '(lambda (x)
					      (angle sz_ins x)
					    )
					   pt_list
				   )
			    )
			    (length pt_list)
			 )
	  )
	  (entmod (subst (cons 50 (+ angle_sz (/ pi 4.0)))
			 (assoc 50 (entget sz_ent))
			 (entget sz_ent)
		  )
	  )
	)
      )
      (entdel c1)
      (setq i (1+ i))
    )
  )
  (command ".undo" "_e")
  (princ)
)


(defun listremoveatom (delatom lstin)
  (apply
    'append
    (subst
      nil
      (list delatom)
      (mapcar
	'list
	lstin
      )
    )
  )
)