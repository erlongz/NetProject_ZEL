;;; �ɹ��߱���ͼ���ɶ���ͼ

(defun c:b2d (/	       expmapss	file_id	 temp_s	  pt_base  changess
	      gcbhss   jd	jxyss	 layern	  n	   tcfwss
	      tcyss    tm	tmss	 wz	  xjss	   xkzbhss
	      xkzbhwz  xss	zg
	     )
  (setvar "cmdecho" 0)
  (setvar "osmode" 0)

  (if (tblobjname "layer" "GXTK")
    (setvar "clayer" "GXTK")
  )					; ɾchange��
  (setq changess (ssget "x" '((8 . "CHANGE"))))
  (if changess
    (command "erase" changess "")
  )					; ��ͼ��
  (setq	tmss (ssget "x"
		    '((8 . "GXTK")
		      (0 . "TEXT")
		      (1 . "*���¹���ʵ��ͼ")
		     )
	     )
  )
  (if tmss
    (progn
      (setq tm (vl-string-subst
		 "10kV�������߷�����ƽ��ͼ"
		 "���¹���ʵ��ͼ"
		 (cdr (assoc 1 (entget (ssname tmss 0))))
	       )
      )
      (entmod (subst
		(cons 1 tm)
		(assoc 1 (entget (ssname tmss 0)))
		(entget (ssname tmss 0))
	      )
      )
    )
  )					; ���ϽǱ�
  (setq	tcfwss (ssget "x"
		      '((8 . "GXTK")
			(0 . "TEXT")
			(1 . "̽�ⷶΧ*")
		       )
	       )
  )
  (if tcfwss
    (command "erase" tcfwss "")
  )
  (setq expmapss (ssget "x" '((8 . "*exptext,*maptext") (0 . "TEXT"))))
  (if expmapss
    (command "erase" expmapss "")
  )					; ���½Ǳ�
;;;  (setq	jsdwss (ssget "x"
;;;		      '((8 . "GXTK")
;;;			(0 . "TEXT")
;;;			(1 . "���赥λ*")
;;;		       )
;;;	       )
;;;  )
;;;  (if jsdwss
;;;    (command "erase" jsdwss "")
;;;  )					; �ӹ滮���֤���
  (setq	xkzbhss	(ssget "x"
		       '((8 . "GXTK")
			 (0 . "TEXT")
			 (1 . "��Ŀ�ܱ��*")
			)
		)
  )
  (setq	gcbhss (ssget "x"
		      '((8 . "GXTK")
			(0 . "TEXT")
			(1 . "*���*")
		       )
	       )
  )
  (if (and
	(= nil xkzbhss)
	gcbhss
      )
    (progn
      (setq jd (+ (cdr (assoc 50 (entget (ssname gcbhss 0)))) (/ pi 2)))
      (setq wz (cdr (assoc 10 (entget (ssname gcbhss 0)))))
      (setq xkzbhwz (polar wz jd 3))
      (setq zg (cdr (assoc 40 (entget (ssname gcbhss 0))))) ; ��������
      (command "-style" "����1" "����" "" "1.0" "" "" "")
      (setvar "textstyle" "����1")
      (command "text"
	       "j"
	       "bl"
	       xkzbhwz
	       zg
	       (angtos (cdr (assoc 50
				   (entget
				     (ssname gcbhss 0)
				   )
			    )
		       )
		       1
		       8
	       )
	       "��Ŀ�ܱ��:XXXXXXXXXX"
      )
    )
  )					; ���½�
  (setq	xjss (ssget "x"
		    '((8 . "GXTK")
		      (0 . "TEXT")
		      (1 . "*����ƽ��ϵͳ��ͼ*")
		     )
	     )
  )
  (if xjss
    (entmod
      (subst
	(cons 1
	      (strcat (substr (rtos (getvar "cdate")) 1 4)
		      "��"
		      (substr (rtos (getvar "cdate")) 5 2)
		      "�µ���ƽ��ϵͳ��ͼ"
		      (substr (cdr
				(assoc 1
				       (entget
					 (ssname xjss 0)
				       )
				)
			      )
			      (+
				(vl-string-search
				  "ͼ"
				  (cdr
				    (assoc 1
					   (entget
					     (ssname xjss 0)
					   )
				    )
				  )
				)
				3
			      )
		      )
	      )
	)
	(assoc 1 (entget (ssname xjss 0)))
	(entget (ssname xjss 0))
      )
    )
  )

  ;; ���½�


  (if (setq file_id (open "c:/ry.txt" "R"))
    (progn
      (setq temp_s  (read-line file_id)
	    pt_base '()
      )
      (while (/= temp_s nil)
	(setq pt_base (cons temp_s pt_base)
	      temp_s  (read-line file_id)
	)
      )
      (close file_id)
      (setq pt_base (reverse pt_base))
    )
    (setq pt_base (list	"����Ա:��  ��  ��ͼԱ:��  ��"
			"���Ա:������"
		  )
    )
  )







  (setq	tcyss (ssget "x"
		     '((8 . "GXTK")
		       (0 . "TEXT")
		       (1 . "̽��Ա*")
		      )
	      )
  )
  (if tcyss
    (progn

      (entmod (subst
		(cons 1 (nth 0 pt_base))
		(assoc 1 (entget (ssname tcyss 0)))
		(entget (ssname tcyss 0))
	      )
      )
;;;      (setq pt2 (cdr (assoc 10 (entget (ssname tcyss 0)))))

    )
  )
  (setq	jxyss (ssget "x"
		     '((8 . "GXTK")
		       (0 . "TEXT")
		       (1 . "���Ա*")
		      )
	      )
  )
  (if jxyss
    (progn
      (entmod (subst
		(cons 1
		      (strcat (nth 1 pt_base)
			      (strcat "  ����:"
				      (substr
					(rtos
					  (getvar "cdate")
					)
					1
					4
				      )
				      "."
				      (substr
					(rtos
					  (getvar "cdate")
					)
					5
					2
				      )
				      "."
				      (substr
					(rtos
					  (getvar "cdate")
					)
					7
					2
				      )
			      )
		      )
		)
		(assoc 1 (entget (ssname jxyss 0)))
		(entget (ssname jxyss 0))
	      )
      )
;;;      (setq pt1 (cdr (assoc 10 (entget (ssname jxyss 0)))))

    )
  )

;;;  (if (and
;;;	tcyss
;;;	jxyss
;;;      )
;;;    (command "move" tcyss jxyss "" pt1 pt2)
;;;  )					; ����Ҫ�����
  (setq layern (cdr (assoc 2 (tblnext "LAYER" t))))
  (while (/= layern nil)
    (if	(and
	  (/= layern "road_zxx")
	  (/= layern "road-zxx")
	)
      (entmod (subst
		(cons 62 7)
		(assoc 62 (entget (tblobjname "LAYER" layern)))
		(entget (tblobjname "LAYER" layern))
	      )
      )
    )
    (setq layern (cdr (assoc 2 (tblnext "LAYER"))))
  )
  (setq	xss (ssget "x")
	n   0
  )
  (if xss
    (repeat (sslength xss)
      (if (assoc 62 (entget (ssname xss n)))
	(entmod	(subst
		  (cons 62 256)
		  (assoc 62 (entget (ssname xss n)))
		  (entget (ssname xss n))
		)
	)
      )
      (setq n (1+ n))
    )
  )
  (setvar "clayer" "0")
  (princ)
  ;(cb_gx)
)