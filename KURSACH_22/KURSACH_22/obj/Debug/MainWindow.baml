   M S B A M L   `   `   `  ����E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22  5   	       KURSACH_22.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:KURSACH_22     5   	     � Title$  LogExp��5   	   $	��450��6   $	��800��6%    � Icon$. (pack://application:,,,/Resources/All.ico��61    � 	Resources 5	       �� 
TargetType   
btTemplate �� CornerRadius �� 
TargetType �� Property �� Value��%  &	        '�� �     '�� f    �� 5
   
   " ��6   .R�5      �� $ 7��6   
���   �$��2q�6:   
�������$��40��5   (   $	��100��64   ._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��
Войти��6d   5      5      �� 5   
   " ��6   .�5      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5       � ��$ 14(�6)   5      5      ��5      �� 5   
    �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��6   .��5      � 	 � RowDefinitions	 5   
   �� 5      $	��125 �6   6+   �� 5      $��80 �6   6*   �� 5       $
��Auto �6   6,   �� 5!      $��50 �6   6*   �� 5"      $��50 �6   6*   
 � ColumnDefinitions
 5$   
   �� 5%      6!   �� 5&      6!   �� 5'      6!   .+�5)   
   �� $��1��6   $��FRANKLIN GOTHIC MEDIUM)�6"   
�������$��3��6Z    �� TextAlignment$ Center=�6j   $��Center=�6�   $��Center=�6�   $��30(�6�   $��Авторизация��6�    J� Effect 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+         
BlurRadius$ 10Q�6#      Color$ Black��63   5-      � 5.   
   $��2��6   $��2��6   	 5/      �� 50      6#   �� 51      $��15 �6    6.   �� 52      6#   
 54      �� 55      $
��Auto �6#   62   �� 56      6%   .+�58      �� $��0��6   $��0��6(   $��FRANKLIN GOTHIC MEDIUM)�66   $��20(�6Z   
�������$��Логин:��6{   6�   �� 59      -   5         ��Name$ login��59   &   $��1��6   $��0��65   $��FRANKLIN GOTHIC MEDIUM)�6B   $	��200��6f   6t   �� 5:      $��0��6   $��2��6+   $��FRANKLIN GOTHIC MEDIUM)�69   $��20(�6]   
�������$��Пароль:��6~   6�   �� 5;      -   5        $
 pass��5;   '   $��1��6   $��2��66   $��FRANKLIN GOTHIC MEDIUM)�6C   $	��200��6g   6u   5<      �� 5=   
   $��0��6   $��FRANKLIN GOTHIC MEDIUM)�6"   
�������$��1��6Z   $ Center=�6j   $��Center=�6�   $��Center=�6�   $��50(�6�   $��LogExp��6�    5>        5?      $ 10Q�6#   $ Black��63   5A      �� 5B   
   -   5         ��Name$ Enter��5B      #��[  6    $��4��6G   $��
Войти��6T   
�������$��16(�6w   $��3��6�   $	��100��6�   $��40��6�   6�   5C      5D      