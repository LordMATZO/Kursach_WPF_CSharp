   M S B A M L   `   `   `  ���� E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22      KURSACH_22.ShopOrdering   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  $localclr-namespace:KURSACH_22    � Title$  Пополнение��$	��530��$	��800�� � Icon$. (pack://application:,,,/Resources/All.ico�� � 	Resources  �� 
TargetType   
btTemplate �� CornerRadius  btTemplate1  btTemplate2  btTemplate3 �� 
TargetType �� Property �� Value��%4  &	        &	 z     &	 �     &	 �    '��     '�� R    '�� �    �� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$��Заказать���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$!��Добавить товар���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$��Удалить один���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$��Изменить цену���� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��
 �   ��� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��
 ������� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��$ 14(�����  �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��.��� 	 � RowDefinitions	 �� $
��Auto ��� $	��100 ��� $
��Auto �$��84���� $
��53.6 ��� $
��Auto ��� $
��Auto ��� $
��Auto �
 � ColumnDefinitions
 �� �� �� .+�%  Xceed.Wpf.Toolkit.IntegerUpDown  -     Name$ newCost��$��50��$��1��,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$# Новая стоимость��$��20(�
���   �
������� J� Opacity$	 0.4Q�$��7��  -   $ 	goodChAim��$��50��$��0��$ ID Товара��$��20(�
���   �
�������$	 0.4Q�$��7���� $��28��$	��155��$��0��$��FRANKLIN GOTHIC MEDIUM)�
�������$��0��$��Center=�$��Center=�$��25(�$��Виды товаров��$��55,0,54.8,20q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black���� $��28��$	��254��$��0��$��FRANKLIN GOTHIC MEDIUM)�
�������$��2��$��1��$��Center=�$��Center=�$��25(�$+��%Формирование заказа��$��137.2,0,137.6,20q�   $ 10Q�$ Black���� -    ��Name$
 addG��$��10.2,1.4,9.6,16q�$��4��$��1��$��1��#��[ $��30(��� -   $ chngC��$��10.2,1.4,9.6,16q�$��7��$��2��$��1��#��[ $��30(��� -   $ clearG��$��10.2,1.4,9.6,16q�$��4��$��2��$��1��#��[ $��30(��� -   $	 ord��$��10.2,5,9.6,14q�$��5��$��1��$��2��#��[  $��30(��� -    ��Name$ goods_id��$	 0.4Q�$	��350��$��5��
�������
���   �$��1��$��0��$��10,15,9.8,10q�$��Visible=�$��Visible=����� .R���  �� Orientation$ 
Horizontal=�.+���  ��Name$ goodID��$��0 0 10 0q�
����������� *gI+�� $ goodNAME��
����������� *gN+�� -   $ goods_lb��$	��200��$	 0.4Q�$��3��
�������
���   �$��1��$��2��$��1��$��10.2,15,9.6,18.6q�$��Visible=�$��Visible=����� .R��� $ 
Horizontal=�.+��� $��ID Товара��  $ 	req_ident��$��10 0 0 0q�
���   �
�������$ ID Товара��   Text �� *id+�� $-��'Требуемое количество��  $	 qua��$��10 0 0 0q�
���   �
�������$ Количество�� �� *
quantity+