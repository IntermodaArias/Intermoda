   M S B A M L   `   `   `  ����   IntermodaMaquilado3    -Intermoda.Maquilado.View.MaquiladoEmpaqueView   a ]Telerik.Windows.Data, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 @d2http://schemas.microsoft.com/expression/blend/2008    	 Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	   � Title$%  Empaque de Orden de Producción��$	��768��$
��1024��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��2q� �� Padding$ 2q�$
��Left=�$��2q�
�������._���  �� Orientation$ 
Horizontal=�.+��� $��2q�$��
Orden No.:���� $��2q�$��Center=�$
��Left=�$��DemiBold"�����  �� Path$% OrdenProduccion.OrdenProduccion��� $��0��$��2q�$ 2q�$��Right=�$��2q�
�������._��� $ 
Horizontal=�$��Right=�.+��� $��2q�$��Referencia:���� $��2q�$��Center=�$
��Left=�$��DemiBold"����� $  OrdenProduccion.Referencia�� $��1�� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� $��0��$��2q�$ 2q�$��Stretch=�$��2q�
�������._��� $��2q�$ Vertical=�.+��� $��Center=�$��Total���� $��Center=�$��DemiBold"����� $ CantidadTotal� �� StringFormat$ {0:#,0}���� $��1��$��2q�$ 2q�$��Stretch=�$��2q�
�������._��� $��2q�$ Vertical=�.+��� $��Center=�$��Empacado���� $��Center=�$��DemiBold"����� $ CantidadEmpacada�$ {0:#,0}���� $��2��$��2q�$ 2q�$��Stretch=�$��2q�
�������._��� $��2q�$ Vertical=�.+��� $��Center=�$��	Pendiente���� $��Center=�$��DemiBold"����� $ CantidadPendiente�$ {0:#,0}��� $��2�� �� $��3* ��� $��4* �.+��� $��0��$��2q�$��2q�
�������._��  �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��2q�$ 
Horizontal=�.+�(  "Telerik.Windows.Controls.RadButton  $��2q�$	��120��$��
Nueva Caja������ $ CajaNuevaCommand�  $��2q�$	��120��$��Cerrar Caja������ $ CajaCerrarCommand�  $��2q�$	��120��$��Cerrar Orden������ $ OrdenCerrarCommand�� $��1��$��2q� �� $
��Auto ��� $��* �.+��� $��0��$ 
Horizontal=�$��Center=�.+��� $��2q�$��DemiBold"�$��16(�$��	Caja No.:���� $��2q�$��DemiBold"�$��16(�$
��Left=�$��Center=����� $ CajaActualSelected.Numero��� $��1��$ 
Horizontal=�$��Center=�.+��� $��2q�$��DemiBold"�$��16(�$��Lectura:���� $��2q�$��DemiBold"�$��16(�$
��Left=�$��Center=����� $ Lectura�*  $Telerik.Windows.Controls.RadGridView  $��2��$��2q�;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     
IsReadOnly . 	   ShowGroupPanel	 .  *  $Telerik.Windows.Controls.DataControl
   ItemsSource
 �� $ CajaActualDetalleList�   Columns 1  +Telerik.Windows.Controls.GridViewDataColumn  -  'Telerik.Windows.Controls.GridViewColumn   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Talla��   TextAlignment$ Center=�   HeaderTextAlignment$ Center=�   DataMemberBinding �� *Talla.Nombre+  $ * $ 
Cantidad  ��$ Right=�$ Right=� �� *
Cantidad+�� $��1��$��2q�$��2q�
�������._��  �� $
��Auto ��� $��1* ��� $
��Auto ��� $��1* �.+��� $��0��$��2q�$
��Left=�$��Bottom=�$��Cajas��$��DemiBold"�  $��0��$��2q�$��Right=�$	��120��$��Reabrir Caja������ $ CajaReAbrirCommand�  $��1��$��2q� .   . 	 .  
 �� $ CajaList�   SelectedItem �� $ CajaActualSelected� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   $ * $	 No.��$ Center=�$ Center=� �� *Numero+  $ * $ 
Cantidad  ��$ Right=�$ Right=� �� $ OrdenNumero��� $��2��$��2,10,2,2q�$
��Left=�$��Bottom=�$��Tallas��$��DemiBold"�  $��3��$��2q� .   . 	 .  
 �� $ 	TallaList�   $ * $ Talla��$ Center=�$ Center=�  $ * $ Total  ��$ Right=�$ Right=�  $ * $ Empacadas  ��$ Right=�$ Right=�  $ * $ Pendientes  ��$ Right=�$ Right=�