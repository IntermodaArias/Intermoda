   M S B A M L   `   `   `  ����  Lecturas En Planta5    /Intermoda.Produccion.LecturaEnPlanta.MainWindow   5   	   n jTelerik.Windows.Controls.GridView, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2016.2.613.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation     R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J	 FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com 	 5   	     � Title$   ��5      $	��768��6#   $
��1024��60    � WindowStartupLocation$ CenterScreen=�6=    � WindowStyle$ 
ToolWindow=�6b    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��7q�6   $��36(�6(   $��DemiBold"�66   $��Center=�6L   $'��!Lectura de Cupones de Producción��6i   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��5q�6   $��28(�6   $��	Usuario: ��6-   $��Center=�6A   �� 5      $��5q�6   $��28(�6!   $	��250��6/   $��Center=�5      ��5   ;   �� $ Usuario� �� 
IsReadOnly 6Y   �� $ UsuarioIsReadOnly�5      (  "Telerik.Windows.Controls.RadButton  5      $��5q�6    $��Center=�6+   $��28(�6H   $��60��5   G   $��50��6R   	 � ToolTip$	 Ingresar��6^   ��5   V   �� $ LoginCommand�y�5      �� $ LoginButtonVisibility���5      �� 5      $��Images/confirm.png��6   5        5      $��5q�6    $��Center=�6+   $��28(�6H   $��60��5   H   $��50��6S   $	 Salir��6_   ��5   V   �� $ LogoutCommand�y�5      �� $ LogoutButtonVisibility���5      �� 5       $��Images/Cancel.png��6   5"      5#      � 5$   
   $��2��6   $��0,25,0,0q�6    5%      �� 5&      $
��Auto �6    �� 5'      $��25 �6    �� 5(      $
��Auto �6    .+�5*      �� $ 
Horizontal=�6   $��Center=�62   .+�5+      �� $��5q�6   $��28(�6#   $��Cupón: ��61   $��Center=�6C   �� 5,      $��5q�6   $��28(�6%   $��DemiBold"�63   $	��400��6I   $��Center=�5-      ��5,   U   �� $ Cupon�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5-   5   �� $ CuponIsReadOnly�5.      �� 5/      $��1��6   $��5q�6!   $��15��6,   " 	 WpfAnimatedGif.ImageBehavior   AnimatedSource$ Images/connecting1.gif��50         RepeatBehavior$ Forever��6R   y�5/   8   �� $ ConnectingVisibility�50   R   �� 51      $��2��6   $��5,10,5,5q�6!   $��28(�63   $��DemiBold"�6A   
���  ��$��Center=�6h   $��60��6�   ��52      �� $ ErrorMensaje�y�6:   �� $ ErrorMensajeVisibility�53      �� 5:   
   $��3��6   $��28(�6K   ��6$   �� $ 	CuponList���5;      �� 5<      .R�5=      �� $��5q�6    $
��Left=�6+   $	��210��6F   ��6R   �� *Cupon+5>      ��5@      �� 5A      .R�5B      �  � Orientation$ Vertical=�6    5C      5E      �� 5F   
   $��4��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5G      �� $��Center=�6   $��36(�6/   $!��Número de Cupones Leidos: ��6=   �� 5H      $��Center=�6   $��36(�6/   $��DemiBold"�6=   
����  ���5I      �� $ 
CuponCount� �� StringFormat$ {0:#,0}��5J      5K      5L      