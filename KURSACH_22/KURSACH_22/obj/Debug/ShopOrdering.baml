   M S B A M L   `   `   `  ����E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22  5   	       KURSACH_22.ShopOrdering   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $localclr-namespace:KURSACH_22  5   	     � Title$  Пополнение��5	   	   $	��530��6   $	��800��6)    � Icon$. (pack://application:,,,/Resources/All.ico��66    � 	Resources 5
       �� 
TargetType   
btTemplate �� CornerRadius  btTemplate1  btTemplate2  btTemplate3 �� 
TargetType �� Property �� Value��%  &	        &	 �     &	 �    &	 t    '�� G    '�� �    '�� K    �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Заказать��6e   5      5      �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $%��Добавить позицию��6e   5      5      �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Удалить один��6e   5      5      �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5       �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Изменить цену��6e   5!      5"      �� 5$   
   " ��6   .�5%      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5&       � ��
 �   �6+   5'      �� 5(   
   " ��6   .�5)      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5*       � ��
 �����6+   5+      �� 5,   
   " ��6   .�5-      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5.       � ��$ 14(�6)   5/      50      ��51      �� 52   
    �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��6   .��54      � 	 � RowDefinitions	 55   
   �� 56      $
��Auto �6   6,   �� 57      $	��100 �6   6+   �� 58      $
��Auto �6   $��84��6*   6;   �� 59      $
��53.6 �6   6,   �� 5:      $
��Auto �6   6,   �� 5;      $
��Auto �6   6,   �� 5<      $
��Auto �6   6,   
 � ColumnDefinitions
 5>   
   �� 5?      6!   �� 5@      6!   �� 5A      6!   .+�5C   
   %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ newCost��5C   )   $��50��6   $��1��6:   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$# Новая стоимость��6J   $��20(�6f   
���   �
������� J� Opacity$	 0.4Q�6�   $��7��6�   6�     5D   
   -   5        $ 	goodChAim��5D   )   $��50��6   $��0��6<   $ ID Товара��6L   $��20(�6b   
���   �
�������$	 0.4Q�6�   $��7��6�   6�   �� 5E   
   $��28��6   $	��155��6    $��0��6-   $��FRANKLIN GOTHIC MEDIUM)�6:   
�������$��0��6r   $��Center=�6�   $��Center=�6�   $��25(�6�   $��Виды товаров��6�   $��55,0,54.8,20q�6�    J� Effect 5F      3  -System.Windows.Media.Effects.DropShadowEffect  5G         
BlurRadius$ 10Q�6#      Color$ Black��63   5I      �� 5J   
   $��28��6   $	��254��6    $��0��6-   $��FRANKLIN GOTHIC MEDIUM)�6:   
�������$��2��6q   $��1��6�   $��Center=�6�   $��Center=�6�   $��25(�6�   $+��%Формирование заказа��6�   $��137.2,0,137.6,20q�6�    5K        5L      $ 10Q�6#   $ Black��63   5N      �� 5O   
   -   5         ��Name$
 addG��5O      $��10.2,1.4,9.6,16q�6   $��4��68   $��1��6F   $��1��6V   #��[ 6j   $��25(�6�   6�   �� 5P   
   -   5        $ chngC��5P      $��10.2,1.4,9.6,16q�6    $��7��69   $��2��6F   $��1��6V   #��[ 6j   $��30(�6�   6�   �� 5Q   
   -   5        $ clearG��5Q      $��10.2,1.4,9.6,16q�6!   $��4��6:   $��2��6G   $��1��6W   #��[ 6k   $��30(�6�   6�   �� 5R   
   -   5        $	 ord��5R      $��10.2,5,9.6,14q�6   $��5��65   $��1��6B   $��2��6R   #��[  6f   $��30(�6�   6�   �� 5S   
   -   5         ��Name$ goods_id��5S   �   $	 0.4Q�6   $	��350��6    $��5��6-   
�������
���   �$��1��6d   $��0��6q   $��10,15,9.8,10q�6�   $��Visible=�6�   $��Visible=�6�   ��5T      �� 5U      .R�5V      ��  �� Orientation$ 
Horizontal=�6"   .+�5W      ��  ��Name$ goodID��6I   $��0 0 10 0q�6$   
���������6Y   �� *gI+6o   �� 5X      $ goodNAME��67   
���������6I   �� *gN+6_   �� 5Y      $	 cst��67   
���������6D   �� *cSt+6[   5Z      5[      5]      �� 5^   
   -   5        $ goods_lb��5^   �   $	��200��6   $	 0.4Q�6   $��3��6-   
�������
���   �$��1��6d   $��2��6q   $��1��6�   $��10.2,15,9.6,18.6q�6�   $��Visible=�6�   $��Visible=�6�   ��5_      �� 5`      .R�5a      �� $ 
Horizontal=�6"   .+�5b      �� $��ID Товара��6%   68     5c      $ 	req_ident��6.   $��10 0 0 0q�6B   
���   �
�������$ ID Товара��6z      Text 6�   �� *id+6�   �� 5d      $-��'Требуемое количество��6'   6E     5e      $	 qua��6-   $��10 0 0 0q�6;   
���   �
�������$ Количество��6s    6�   �� *
quantity+6�   5f      5g      5i      5j      5k      