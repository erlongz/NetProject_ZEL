;;; 由管线报建图生成定线图

(defun c:b2d (/	       expmapss	file_id	 temp_s	  pt_base  changess
	      gcbhss   jd	jxyss	 layern	  n	   tcfwss
	      tcyss    tm	tmss	 wz	  xjss	   xkzbhss
	      xkzbhwz  xss	zg
	     )
  (setvar "cmdecho" 0)
  (setvar "osmode" 0)

  (if (tblobjname "layer" "GXTK")
    (setvar "clayer" "GXTK")
  )					; 删change层
  (setq changess (ssget "x" '((8 . "CHANGE"))))
  (if changess
    (command "erase" changess "")
  )					; 改图名
  (setq	tmss (ssget "x"
		    '((8 . "GXTK")
		      (0 . "TEXT")
		      (1 . "*地下管线实测图")
		     )
	     )
  )
  (if tmss
    (progn
      (setq tm (vl-string-subst
		 "10kV电力管线放线总平面图"
		 "地下管线实测图"
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
  )					; 改上角标
  (setq	tcfwss (ssget "x"
		      '((8 . "GXTK")
			(0 . "TEXT")
			(1 . "探测范围*")
		       )
	       )
  )
  (if tcfwss
    (command "erase" tcfwss "")
  )
  (setq expmapss (ssget "x" '((8 . "*exptext,*maptext") (0 . "TEXT"))))
  (if expmapss
    (command "erase" expmapss "")
  )					; 改下角标
;;;  (setq	jsdwss (ssget "x"
;;;		      '((8 . "GXTK")
;;;			(0 . "TEXT")
;;;			(1 . "建设单位*")
;;;		       )
;;;	       )
;;;  )
;;;  (if jsdwss
;;;    (command "erase" jsdwss "")
;;;  )					; 加规划许可证编号
  (setq	xkzbhss	(ssget "x"
		       '((8 . "GXTK")
			 (0 . "TEXT")
			 (1 . "项目总编号*")
			)
		)
  )
  (setq	gcbhss (ssget "x"
		      '((8 . "GXTK")
			(0 . "TEXT")
			(1 . "*编号*")
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
      (setq zg (cdr (assoc 40 (entget (ssname gcbhss 0))))) ; 设置字形
      (command "-style" "黑体1" "黑体" "" "1.0" "" "" "")
      (setvar "textstyle" "黑体1")
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
	       "项目总编号:XXXXXXXXXX"
      )
    )
  )					; 左下角
  (setq	xjss (ssget "x"
		    '((8 . "GXTK")
		      (0 . "TEXT")
		      (1 . "*电子平板系统测图*")
		     )
	     )
  )
  (if xjss
    (entmod
      (subst
	(cons 1
	      (strcat (substr (rtos (getvar "cdate")) 1 4)
		      "年"
		      (substr (rtos (getvar "cdate")) 5 2)
		      "月电子平板系统测图"
		      (substr (cdr
				(assoc 1
				       (entget
					 (ssname xjss 0)
				       )
				)
			      )
			      (+
				(vl-string-search
				  "图"
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

  ;; 右下脚


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
    (setq pt_base (list	"测量员:张  三  绘图员:李  四"
			"检查员:王麻子"
		  )
    )
  )







  (setq	tcyss (ssget "x"
		     '((8 . "GXTK")
		       (0 . "TEXT")
		       (1 . "探测员*")
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
		       (1 . "检查员*")
		      )
	      )
  )
  (if jxyss
    (progn
      (entmod (subst
		(cons 1
		      (strcat (nth 1 pt_base)
			      (strcat "  日期:"
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
;;;  )					; 所有要素随层
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