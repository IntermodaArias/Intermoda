   M S B A M L   `   `   `  ����  IntermodaMaquilado3    -Intermoda.Maquilado.View.MaquiladoEmpaqueView   5   	   a ]Telerik.Windows.Data, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 5   	   @d2http://schemas.microsoft.com/expression/blend/2008    	 5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 5   	     � Title$%  Empaque de Orden de Producción��5      $	��768��6A   $
��1024��6N   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2q�6    �� Padding$ 2q�6)   $
��Left=�65   $��2q�6P   
�������._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��2q�6   $��
Orden No.:��6#   �� 5      $��2q�6   $��Center=�6'   $
��Left=�6B   $��DemiBold"�5      ��62   ��  �� Path$% OrdenProduccion.OrdenProduccion�5      5      �� 5   
   $��0��6   $��2q�6   $ 2q�6)   $��Right=�65   $��2q�6Q   
�������._�5      �� $ 
Horizontal=�6   $��Right=�62   .+�5      �� $��2q�6   $��Referencia:��6#   �� 5      $��2q�6   $��Center=�6'   $
��Left=�6B   $��DemiBold"�5      ��62   �� $  OrdenProduccion.Referencia�5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5       $��* �6#   .+�5"      �� $��0��6   $��2q�6%   $ 2q�60   $��Stretch=�6<   $��2q�6Z   
�������._�5#      �� $��2q�6   $ Vertical=�6(   .+�5$      �� $��Center=�6   $��Total��69   �� 5%      $��Center=�6    $��DemiBold"�6=   ��6S   �� $ CantidadTotal� �� StringFormat$ {0:#,0}��5&      5'      �� 5(      $��1��6   $��2q�6%   $ 2q�60   $��Stretch=�6<   $��2q�6Z   
�������._�5)      �� $��2q�6   $ Vertical=�6(   .+�5*      �� $��Center=�6   $��Empacado��69   �� 5+      $��Center=�6    $��DemiBold"�6=   ��6S   �� $ CantidadEmpacada�$ {0:#,0}��5,      6    �� 5-      $��2��6   $��2q�6%   $ 2q�60   $��Stretch=�6<   $��2q�6Z   
�������._�5.      �� $��2q�6   $ Vertical=�6(   .+�5/      �� $��Center=�6   $��	Pendiente��69   �� 50      $��Center=�6    $��DemiBold"�6=   ��6S   �� $ CantidadPendiente�$ {0:#,0}��51      6    52      � 53   
   $��2��6    54      �� 55      $��3* �6#   �� 56      $��4* �6#   .+�58      �� $��0��6   $��2q�6%   $��2q�60   
�������._�59      �  5:      �� 5;      $
��Auto �6(   �� 5<      $
��Auto �6(   �� 5=      $��* �6(   .+�5?      �� $��0��6!   $��2q�6.   $ 
Horizontal=�69   .+�5@      (  "Telerik.Windows.Controls.RadButton  $��2q�6,   $	��120��67   $��
Nueva Caja��6C   ��6X   �� $ CajaNuevaCommand�  5A      $��2q�6,   $	��120��67   $��Cerrar Caja��6C   ��6Y   �� $ CajaCerrarCommand�  5B      $��2q�6,   $	��120��67   $��Cerrar Orden��6C   ��6Z   �� $ OrdenCerrarCommand�5C      � 5D      $��1��6   $��2q�6(    5E      �� 5F      $
��Auto �6,   �� 5G      $��* �6,   .+�5I      �� $��0��6%   $ 
Horizontal=�62   $��Center=�6K   .+�5J      �� $��2q�6$   $��DemiBold"�6/   $��16(�6E   $��	Caja No.:��6S   �� 5K      $��2q�6(   $��DemiBold"�63   $��16(�6I   $
��Left=�6W   $��Center=�5L   (   ��6C   �� $ CajaActualSelected.Numero�5M      �� 5N      $��1��6%   $ 
Horizontal=�62   $��Center=�6K   .+�5O      �� $��2q�6$   $��DemiBold"�6/   $��16(�6E   $��Lectura:��6S   �� 5P      $��2q�6&   $��DemiBold"�61   $��16(�6G   $
��Left=�6U   $��Center=�5Q   &   ��5R   &   �� $ Lectura�5S      5T      *  $Telerik.Windows.Controls.RadGridView  5U      $��2��6*   $��2q�67   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     
IsReadOnly . 	   ShowGroupPanel	 .  *  $Telerik.Windows.Controls.DataControl
   ItemsSource
 5V   A   �� $ CajaActualDetalleList�   Columns 5W      1  +Telerik.Windows.Controls.GridViewDataColumn  5X      -  'Telerik.Windows.Controls.GridViewColumn   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 69   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Talla��6C      TextAlignment$ Center=�6R      HeaderTextAlignment$ Center=�5Y   9      DataMemberBinding 6V   �� *Talla.Nombre+  5Z      $ * 69   $ 
Cantidad  ��6C   $ Right=�6W   $ Right=�5[   9    6U   �� *
Cantidad+5]      5^      5_      �� 5`      $��1��6   $��2q�6%   $��2q�60   
�������._�5a      �  5b      �� 5c      $
��Auto �6(   �� 5d      $��1* �6(   �� 5e      $
��Auto �6(   �� 5f      $��1* �6(   .+�5h      �� $��0��6   $��2q�6)   $
��Left=�64   $��Bottom=�6O   $��Cajas��5i      $��DemiBold"�6,     5j      $��0��6(   $��2q�65   $��Right=�6@   $	��120��6\   $��Reabrir Caja��5k   (   ��6?   �� $ CajaReAbrirCommand�  5l      $��1��6*   $��2q�67    .   . 	 .  
 5m   A   �� $ CajaList�   SelectedItem 5n   *   �� $ CajaActualSelected� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5o        5p      $ * 69   $	 No.��6C   $ Center=�6P   $ Center=�5q   9    6V   �� *Numero+  5r      $ * 69   $ 
Cantidad  ��6C   $ Right=�6W   $ Right=�5s   9    6U   �� $ OrdenNumero�5u      �� 5v      $��2��6   $��2,10,2,2q�6)   $
��Left=�6;   $��Bottom=�6V   $��Tallas��5w      $��DemiBold"�6-     5x      $��3��6*   $��2q�67    .   . 	 .  
 5y   A   �� $ 	TallaList� 5z        5{      $ * 69   $ Talla��6C   $ Center=�6R   $ Center=�5|   9     5}      $ * 69   $ Total  ��6C   $ Right=�6T   $ Right=�5~   9     5      $ * 69   $ Empacadas  ��6C   $ Right=�6X   $ Right=�5�   9     5�      $ * 69   $ Pendientes  ��6C   $ Right=�6Y   $ Right=�5�   9   5�      5�      5�      5�      5�      5�      