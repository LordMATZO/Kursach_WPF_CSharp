   M S B A M L   `   `   `  ���� E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22      KURSACH_22.Manager   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  $localclr-namespace:KURSACH_22    � Title$  Доставка��$��841.6��$	��800�� � Icon$. (pack://application:,,,/Resources/All.ico�� � 	Resources  �� 
TargetType   
btTemplate �� CornerRadius  btTemplate3  btTemplate2  btTemplate1 �� 
TargetType �� Property �� Value��%&  &	        &	 �     &	     &	 �    '�� 6    '�� �    �� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$+��%Зафиксировать склад���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$#��Очистить список���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$)��#Сформировать заказ���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$/��)Добавить товар в заказ���� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��
 ������� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��$ 14(���  � ��
 �   �����  �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��.��� $��0,0,-0.4,-0.2q�	 � RowDefinitions	 �� $��60 ��� $	��100 ��� $
��152* ��� $
��152* ��� $
��Auto ��� $
��Auto �$	��152���� $
��Auto �$
��72.8���� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �
 � ColumnDefinitions
 �� �� .+��� $��0��$��FRANKLIN GOTHIC MEDIUM)�
�������$��0�� �� TextAlignment$ Center=�$��Center=�$��Center=�$��25(�$��Склады��$��28��$��158,16,157.8,16q�$��81�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black���� -    ��Name$ warList�� J� Opacity$	 0.4Q�$��1��
�������
���   �$��1��$��0��$��Visible=�$��Visible=����� .R���  �� Orientation$ 
Horizontal=�.+��� 
����������� *whID+�� -   $ reqList��$	 0.4Q�$��1��
�������
���   �$��1��$��1��$��Visible=�$��Visible=����� .R��� $ 
Horizontal=�.+��� 
����������� *reqID+�� 
����������� *shopID+�� $��28��$	��223��$��0��$��FRANKLIN GOTHIC MEDIUM)�
�������$��1��$��Center=�$��Center=�$��25(�$'��!Запросы магазинов��$��87.2,16,86.6,16q�   $ 10Q�$ Black���� -   $ 	req_goods��$	 0.4Q�$��2��
�������
���   �$��2��$��1��$��10.2,9.6,9.6,10.4q�$��Visible=�$��Visible=����� .R��� $ 
Horizontal=�.+��� 
�������
���   ����� *goodID+�� 
�������
���   ����� *quan+�� -    ��Name$ formReq��$��97,5,96.6,5q�$��10��$��2��#��[ $��30(��� -   $ addGiT��$��10 10 10 10q�$��9��$��1��#��[ $��30(��� -   $ clearGiT��$��10 10 10 10q�$��9��$��1��$��1��#��[ $��30(��� -   $ fixer��$	��220��$��4��$��40��#��[  $��1��$��20(��� -   $ warehouseGoods��$	 0.4Q�$��2��
�������
���   �$��2��$��0��$��10,9.6,9.8,10.4q�$��Visible=�$��Visible=����� .R��� $ 
Horizontal=�.+��� 
�������
���   ����� *goodID+�� 
�������
���   ����� *quan+%  Xceed.Wpf.Toolkit.IntegerUpDown  -	     Name$ sourceWH��$	��300��,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$4 .ID Распределяемого склада��
�������$��30��$��20(�$��0��$��4���� -
   $ ready_quest��$	 0.4Q�$��2��
�������
���   �$��5��$��0��$��2��$��10,9.8,9.6,10q�$	��200��$��Visible=�$��Visible=����� .R��� $ 
Horizontal=�.+�  $ REQ_ID_Z��$	��300��$0 *ID Исполняемого запроса��
�������$��30��$��20(�$��0��$��2��$��7��   Text �� *reqId+  $ 	GOOD_ID_Z��$	��300��$ ID Товара��
�������$��30��$��20(�$��0��$��1��$��8�� �� *goodId+