   M S B A M L   `   `   `  ����?  ;SMIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SMISSMIS  5   	       SMIS.AccountWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SMIS     5   	   -   5          � Title$  AccountWindow��5   	   $	��600��6   $
��1024��6,    � WindowStyle$
 None=�69    � AllowsTransparency .  � 
ResizeMode$ NoResize=�6f   ���	#FF272727.��5
      � .+�5   
   �� $��Account��6   $
��Left=�6"   $��	30,10,0,0q�6=   $	��Top=�6P   $��48(�6h   
�������6v   �� 5   
   -   5         ��Name$ btn_home��5      $
��home��6#   $��	0,17,17,0q�62   $��50��6E   $��50��6Q   $	��Top=�6\   $��Right=�6t   ���	#FF3F3F466�   � 5   
   $��30,90,30,40q�6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��2* �6#   .+�5      �� -   5         ��Name$ img_thumbnail��5      $	��256��6+   $��
33,10,33,0q�68   $	��Top=�6L   �� 5      -   5        $ btn_profileChage��5      $��사진 변경��6/   $
��Left=�6?   $��
33,271,0,0q�6Z   $	��Top=�6n   ���	#FF272727
�������$��0q�5   ?   $��14(�6S   6a   � 5      $��1��6    5      �� 5      $��1* �6'   �� 5      $��5* �6'    � RowDefinitions 5      �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5       $��1* �6$   �� 5!      $��1* �6$   �� 5"      $��1* �6$   �� 5#      $��1* �6$   �� 5$      $��1* �6$   �� 5%      $��2* �6$   .+�5'      �� $��
닉네임:��6   $
��Left=�6'   $��10,0,0,0q�6B   $	��Top=�6T   
�������6l   �� 5(      $��계정:��6   $
��Left=�6&   $��10,0,0,0q�6A   $	��Top=�6S   
�������$��1��6}   �� 5)      $��상태:��6   $
��Left=�6&   $��10,0,0,0q�6A   $	��Top=�6S   
�������$��2��6}   �� 5*      $��상태 메세지:��6   $
��Left=�6*   $��10,0,0,0q�6E   $	��Top=�6W   
�������$��3��6�   �� 5+      $��휴대 전화:��6   $
��Left=�6)   $��10,0,0,0q�6D   $	��Top=�6V   
�������$��4��6�   �� 5,      $��집 전화:��6   $
��Left=�6(   $��10,0,0,0q�6C   $	��Top=�6U   
�������$��6��6   �� 5-      $��회사 전화:��6   $
��Left=�6)   $��10,0,0,0q�6D   $	��Top=�6V   
�������$��5��6�   �� 5.      $��
이메일:��6   $
��Left=�6'   $��10,0,0,0q�6B   $	��Top=�6T   
�������$��7��6~   �� 54      -   5         ��Name$ lbl_nickname��54      $��	닉네임��6.   $
��Left=�6<   $��10,0,0,0q�6W   $	��Top=�6i   
�������$��16(�6�   $��1��6�   �� 55      -   5        $ lbl_account��55      $��계정��6-   $
��Left=�6:   $��10,0,0,0q�6U   $	��Top=�6g   
�������$��14(�6�   $��1��6�   $��1��6�   �� 56      -   5        $ lbl_comment��56      $��상태 메세지��6-   $
��Left=�6>   $��10,0,0,0q�6Y   $	��Top=�6k   
�������$��14(�6�   $��1��6�   $��3��6�   �� 57      -   5        $ lbl_phoneNum��57      $��휴대 전화��6.   $
��Left=�6>   $��10,0,0,0q�6Y   $	��Top=�6k   
�������$��14(�6�   $��1��6�   $��4��6�   �� 58      -	   5        $ lbl_companyNum��58      $��회사 전화��60   $
��Left=�6@   $��10,0,0,0q�6[   $	��Top=�6m   
�������$��14(�6�   $��1��6�   $��5��6�   �� 59      -
   5        $ lbl_homeNum��59      $��
집 전화��6-   $
��Left=�6<   $��10,0,0,0q�6W   $	��Top=�6i   
�������$��14(�6�   $��1��6�   $��6��6�   �� 5:      -   5        $ 	lbl_Email��5:      $��	이메일��6+   $
��Left=�69   $��10,0,0,0q�6T   $	��Top=�6f   
�������$��14(�6�   $��1��6�   $��7��6�   �� 5@      -   5        	 ��Name$	 txt_nickname��5@      $��1��60   $
��Left=�6@   $��22��6[   $��	243,0,0,0q�6g   
 �� TextWrapping$

 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF3F3F46$y�Hidden=�6�   �� 5A      -   5         ��Name$ 	cmb_state��5A      $��1��6.   $
��Left=�6>   $��10,0,0,0q�6Y   $	��Top=�6k   $	��120��6�   $��2��6�   6�   �� 5B      -   5        $	 txt_comment��5B      $��1��6/   $
��Left=�6?   $��22��6Z   $��	243,0,0,0q�6f   $

 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF3F3F46$��3��6�   $y�Hidden=�6�   �� 5C      -   5        $	 txt_phoneNum��5C      $��1��60   $
��Left=�6@   $��22��6[   $��	243,0,0,0q�6g   $

 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF3F3F46$��4��6�   $y�Hidden=�6�   �� 5D      -   5        $	 txt_companyNum��5D      $��1��62   $
��Left=�6B   $��22��6]   $��	243,0,0,0q�6i   $

 Wrap=�6|   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF3F3F46$��5��6�   $y�Hidden=�6�   �� 5E      -   5        $	 txt_homeNum��5E      $��1��6/   $
��Left=�6?   $��22��6Z   $��	243,0,0,0q�6f   $

 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF3F3F46$��6��6�   $y�Hidden=�6�   �� 5F      -   5        $	 	txt_Email��5F      $��1��6-   $
��Left=�6=   $��22��6X   $��	243,0,0,0q�6d   $

 Wrap=�6w   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF3F3F46$��7��6�   $y�Hidden=�6�   �� 5L      -   5        $ 
btn_modify��5L      $��수정��6-   $��1��6:   $��Right=�6J   $��0,0,80,0q�6f   $��Bottom=�6x   $��75��6�   $��8��6�   6�   �� 5M      -   5        $ btn_save��5M      $��저장��6+   $��1��68   $��Right=�6H   $��0,0,80,0q�6d   $��Bottom=�6v   $��75��6�   $��8��6�   $y�Hidden=�6�   6�   5N      5O      5P      5Q      