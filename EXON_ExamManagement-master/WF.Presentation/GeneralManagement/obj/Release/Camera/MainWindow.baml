   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  GeneralManagement)   #GeneralManagement.Camera.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     `hostOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     Twinform@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     6sys&clr-namespace:System;assembly=mscorlib       � Title$  Giám Sát Camera��$	��696��$
��1283�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � 	Resources    
ID_GENERAL 
 ID_PTZ  ID_ADD_DEVICE  ID_DEL_DEVICE  ID_STOPREAL  ID_STOPALLREAL  ID_OPENSOUND  ID_CLOSESOUND  ID_SAVEREALDATA 	 ID_STOPREALDATA 
 
ID_CAPTURE  ID_DEVICELIST  ID_ZOOM  ID_FOCUS  ID_APERTURE  ID_LOGIN_IP_ERROR  ID_LOGIN_PORT_ERROR  ID_LOGIN_USERNAME_ERROR  	ID_ONLINE  
ID_OFFLINE  
ID_CHANNEL  ID_MAINSTREAM  ID_SUBSTREAM  ID_PORTERROR��%  &	        &	      &	 (     &	 >     &	 S     &	 h     &	 �     &	 �     &	 �     &		 �     &	
 �     &	      &	     &	 *    &	 :    &	 M    &	 o    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     ��Quản Lý Camera����PTZ����Thêm Camera����Xóa Camera����Dừng quay����Dừng quay tất cả����	OpenSound����
CloseSound����Lưu dữ liệu����Dừng lưu dữ liệu����Chụp ảnh����Danh sách camera����	Zoom:����
Focus:����	Aperture:����Please input ip address!����Please input port!����Please input username!����(online)����	(offline)����	Kênh����main stream����
sub stream����Port is out of range!��.��� $��10q� � RowDefinitions �� $
��185* ��� $
��394* � � ColumnDefinitions �� $	��200 ��� $��* �.+�� $��0��$��2�� �� $��* ��� $	��280 �.+�� $��0��.+��� .@��� #���   $��98��.���� 
�������$��1q� �� CornerRadius$ 2��$��	0,0,0,-13q�$	��270��$	��Top=�._��� $��	0,0,0,-20q�.+���  �� Orientation$ 
Horizontal=�$��0,10,0,0q�$��Center=�.+��� -   $��25��$��80��$��0,10,0,0q�#���  �� -   $��25��$��80��$��	10,10,0,0q�#���  �� .+��� -    ��Name$ type_combox��$��0,10,0,0q�$	��170��$��25���� $ 
Horizontal=�$��Center=�.+��� -   $��25��$��62��$��0,10,0,0q�#���  �� -   $��25��$��99��$��	10,10,0,0q�#���  �� $ 
Horizontal=�$��Center=�$��5q��� -   #���  $��0,10,0,0q�$��25��$	��170���� -   #��� 	 $��0,10,0,0q�$��25��$	��170���� -   #��� 
 $��
11,10,11,0q�$��25��$	��170��� $��1�� �� $	��23* ��� $	��17* �.+��� #���  $��2��$��	0,-62,0,0q�.��R� -	   	 R�Name$	 treeView��$��0,31,0,0q�� -
   
 �Name$
 
showPanel1��$��1��$��2��.+��� 
�������$	��0.5q�._��  �� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* �.+�� $��0��$��0��.+��� 
���  ��$��1q�$��2q�
����·�._�7   1System.Windows.Forms.Integration.WindowsFormsHost  -     Name$ host0��   Child. %  System.Windows.Forms.PictureBox  -   realPlayLayout0��"  System.Windows.Forms.Control
   Tag$ 0��� $��0��$��1��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host1��.   -   realPlayLayout1��$ 1��� $��0��$��2��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host2��.   -   realPlayLayout2��$ 2��� $��1��$��0��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host3��.   -   realPlayLayout3��$ 3��� $��1��$��1��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host4��.   -   realPlayLayout4��$ 4��� $��1��$��2��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host5��.   -   realPlayLayout5��$ 5��� $��2��$��0��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host6��.   -   realPlayLayout6��$ 6��� $��2��$��1��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host7��.   -   realPlayLayout7��$ 7��� $��2��$��2��.+��� 
�������$��1q�$��2q�
����·�._�  -   $ host8��.   -   realPlayLayout8��$ 8��� -   $
 
showPanel2��$��1��$y�	Collapsed=�$��2��.+��� 
�������$��2q�
����·�._�  -   $ winFormHost��