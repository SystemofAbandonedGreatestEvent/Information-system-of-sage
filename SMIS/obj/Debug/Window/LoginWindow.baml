   M S B A M L   `   `   `  ����?  ;SMIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SMISSMIS  5   	       SMIS.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SMIS     5   	     � Title$  Login��5      $	��480��6   $	��800��6"    � 
ResizeMode$ CanMinimize=�6.   ���#272727 � 	Resources 5	       �� Source�� 5
   
   $! /Themes/ExpressionDark.xaml?�6   %    .��5      � .+�5   
   �� -   5         ��Name$	 img��5      $
��Left=�6   $��
10,10,0,10q�68   $	��501��6L   �� 5   
   -   5         ��Name$ tbc_sign��5      $��516,10,10,10q�6'    �� SelectedIndex$ 1��6=   .@�5      �� $��Sign up��6   ��5      �� 5       �� EndPoint$	 0,1&�6*    �� 
StartPoint$	 0,0&�69   .��5      � 	 � Color$	 	#FFF0F0F0��6'   
 � Offset$
 0Q�69   � 5      $	 	#69696969��6'   $
 1Q�69   5      .��5      � 
���iii�.+�5      �� $��계정 등록하기��6   $
��Left=�6.   $��	10,10,0,0q�6I   $	��Top=�6\   $��18(�6t   $
��Bold"�6�   �� 5      $��
아이디:��6   $
��Left=�6+   $��	10,59,0,0q�6F   $	��Top=�6Y   �� 5      -   5         ��Name$ txt_signupID��5      $��23��64   $��
10,80,10,0q�6@    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p    �� 	MaxLength$ 30��6�   6�   �� 5      $��비밀번호:��6   $
��Left=�6,   $��
10,118,0,0q�6G   $	��Top=�6[   G� 5      -   5         G�Name$ txt_signupPW��5   "   $��23��68   $��10,139,10,0q�6D   $	��Top=�6Y    G� 	MaxLength$ 30��6q   6�   �� 5      $A��;등록을 클릭하면 다음에 동의하는 것입니다:��6   $
��Left=�6>   $	��Top=�6Y   $��
10,167,0,0q�6q   $��9(�6�   ���	#A9A9A9A9$��2��6�   �� 5      -   5         ��Name$ lbl_05��5      $��사용약관��6,   $
��Left=�6;   $��
10,242,0,0q�6V   $	��Top=�6j   ���	#A9A9A9A96�   �� 5      -   5        $ label5��5      $��개인정보 보호정책��6,   $
��Left=�6@   $��
10,263,0,0q�6[   $	��Top=�6o   ���	#A9A9A9A9$��2��6�   �� 5      -   5         ��Name$ 
btn_signUp��5      $��등록하기��61   $
��Left=�6@   $��
10,284,0,0q�6[   $	��Top=�6o   $��75��6�   {�.  6�   5       5!      �� 5"      $��Login��6   .��5#      � 
���iii�.+�5$      �� $��	로그인��6   $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   $��18(�6p   $
��Bold"�6~   �� 5%      $��
아이디:��6   $
��Left=�6+   $��	10,49,0,0q�6F   $	��Top=�6Y   $��2��6q   �� 5&      -   5        $ txt_signinID��5&      $��23��64   $��
10,80,10,0q�6@   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $ 30��6�   6�   �� 5'      $��비밀번호:��6   $
��Left=�6,   $��
10,118,0,0q�6G   $	��Top=�6[    J� RenderTransformOrigin$ 0.993,1.256&�6s   G� 5(      -	   5        $ txt_signinPW��5(   "   $��23��68   $��10,139,10,0q�6D   $	��Top=�6Y   $ 30��6q   6�   �� 5)      -
   5        $ 	btn_login��5)      $��	로그인��60   $��183,167,10,0q�6>   $	��Top=�6T   {�.  6~   5*      5+      5-      5/      50      