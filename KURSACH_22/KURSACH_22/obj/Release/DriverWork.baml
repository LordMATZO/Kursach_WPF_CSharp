   M S B A M L   `   `   `  ���� E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22      KURSACH_22.DriverWork   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  $localclr-namespace:KURSACH_22    � Title$  Доставка��$	��450��$	��800�� � Icon$. (pack://application:,,,/Resources/All.ico�� � 	Resources  �� 
TargetType   
btTemplate �� CornerRadius  btTemplate2  btTemplate1 �� 
TargetType �� Property �� Value��%O  &	        &	 t     &	 �     '�� i    '�� �    �� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$��
Отвёз���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$��Создать отчёт���� " ��.R��� $ 10��
���   �$��2q�
�������._��� $��5q�$��Center=�$��Center=�$��Взял���� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��
 ������� " ��.���  � ��$ FRANKLIN GOTHIC MEDIUM)���  � ��$ 14(���  � ��
 �   �����  �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��.��� 	 � RowDefinitions	 �� $��60 ��� $
��Auto ��� �� $
��Auto ��� $
��Auto ��� $��70 �
 � ColumnDefinitions
 �� �� .+��� $��0��$��FRANKLIN GOTHIC MEDIUM)�
�������$��0�� �� TextAlignment$ Center=�$��Center=�$��Center=�$��25(�$��Заметки�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ Black���� $
��Auto��$
��Auto��$��0��$��FRANKLIN GOTHIC MEDIUM)�
�������$��1��$��Center=�$��Center=�$��25(�$'��!Пункты назначения��   $ 10Q�$ Black���� -    ��Name$ completeBut��$��5��$��2��#��[ $	��600��$��60��$��30(��� -   $ takeBut��$��3��$��1��#��[ $��40��$��20(�$	��120���� -    ��Name$ destinations�� J� Opacity$	 0.4Q�$��3��
�������
���   �$��1��$��1��$��10q�$��Visible=�$��Visible=����� .R���  �� Orientation$ 
Horizontal=�.+���  ��Name$ tb��
�������
���   ����� *shpID+�� -    ��Name$ hints��
������� �� TextWrapping$
 Wrap=�$��1��$��2��
���   �$	 0.4Q�$��10q�"  Xceed.Wpf.Toolkit.TimePicker  -     Name$ st��$	 0.4Q�$��10 0 0 0q�
���   �$��0��$��4��
�������,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ Время начала��  -   $ et��$	 0.4Q�$��10 0 0 0q�
���   �$��1��$��4��
�������$ Время конца��