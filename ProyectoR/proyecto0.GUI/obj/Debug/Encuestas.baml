   M S B A M L   `   `   `  ����H  Dproyecto0.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:proyecto0.GUIproyecto0.GUI  5   	       proyecto0.GUI.Encuestas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:proyecto0.GUI     5   	     � Title$  Encuesta��5      $	��350��6   $	��615��6%   ��5	      �� 5
   
    �� ImageSource$ Imagen/thYI7QF0N8.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��227* �6   �� 5      $
��380* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   $	��248��6*   �� 5      $
��auto �6   $��66��6*   �� 5      $
��auto �6   $��4��6*   .+�5   
   � $��0��6   $��0��6$   $��10q�61   ��5      �� 5      $# Imagen/cucharete_logo_170.jpg��6   5      � 5   
    � Orientation$ 
Horizontal=�6   $	��320��6-   $��Center=�69   $��1��6W   $��
30,10,30,0q�6g   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��90��6   $
��Bold"�6#   $��16(�65   .��6D   
Empresa:6N   �� 5      -   5         ��Name$ CmbEmpresaEncuesta��5      $	��220��67   $��2q�6C   6P   5       �� 5!      $��0��6   $ 
Horizontal=�6&   .+�5"      �� $��90��6   $
��Bold"�6#   $��16(�65   .��6C   	Nombre:6L   �� 5#      -   5        $ CmbNombreEncuesta��5#      $	��220��66   $��2q�6B   6O   5$      �� 5%      $��1��6   $ 
Horizontal=�6&   .+�5&      �� $��90��6   $
��Bold"�6#   $��16(�65   .��6C   	Dueño:6K   �� 5'      -   5         ��Name$ txtDuenoEncuesta��5'      $	��220��64   $��2q�6@   6M   5(      �� 5)      $��2��6   $ 
Horizontal=�6&   .+�5*      �� $��90��6   $
��Bold"�6#   $��16(�65   .��6C   	Objetivo:6N   �� 5+      -   5        $ txtObjetivoEncuesta��5+      $	��220��67   $��80��6C   $��2q�6O   6\   5,      �� 5-      $��2��6   $ 
Horizontal=�6&   .+�5.      �� $��90��6   $
��Bold"�6#   $��16(�65   .��6C   	Password:6N   G� 5/      -   5         G�Name$ txtPasswordEncuesta��5/      $	��220��6;   $��2q�6G   50      51      �� 52   
   -   5        	 ��Name$	 EntrarEncuesta��52   c   $��30��6   $��1��6   $��Center=�6+   $��80��6H   $��1��6S   .��53      �� $ 
Horizontal=�6   .+�54      �� $
��Bold"�6   .��6*   Entrar62   �� 55      $��16��6   $��/Imagen/door_in.png��6#   6D   56      57      �� 58   
   -   5        $	 btnConfiguracion��58   9   $��0��6   $��1��6!   $��50��6.   $��
75,18,0,15q�6r   $
��Left=�6�   $��33��6�   ���	#FF474545��6�   Z� .��59      �� $��/Imagen/cog.png��6   $��30��6-   $��32��69   6F   5:      5<      5=      