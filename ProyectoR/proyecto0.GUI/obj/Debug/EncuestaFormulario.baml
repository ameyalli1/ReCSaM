   M S B A M L   `   `   `  ����H  Dproyecto0.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:proyecto0.GUIproyecto0.GUI  5   	   &     proyecto0.GUI.EncuestaFormulario   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:proyecto0.GUI     5   	     � Title$  Encuesta��5   	   $	��350��6   $	��515��6'   ��5	      �� 5
   
    �� ImageSource$ Imagen/thYI7QF0N8.jpg��6   .��5      � ��5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $	��42* �6   �� 5      $
��127* �6    � RowDefinitions 5   
   �� 5      $	��78* �6   �� 5      $
��179* �6   �� 5      $	��62* �6   .+�5   
   � $��0��6   $��1��6$    � Orientation$ Vertical=�61   $��Center=�6H   $
��10,0q�6e   $	��106��6s   
�������.+�5      �� $��Center=�6   $
��Bold"�61   $��14(�6C   $	��103��6Q   .��6]   
PREGUNTA6g   �� 5      -   5         ��Name$ txtNumeroPregunta��5      $��50��61   $��Center=�6<   $��30��6Y   $
��Bold"�6�   ���	#FF01041F��6e   Z� ��6{   Z� 6�   �� 5      -   5        $ txtIDMesero��5       �� 
IsReadOnly . $��2��6=   ��6G   Z� ��6]   Z� ��6s   Z� 6�   �� 5      -   5        $ txtIDEncuesta��5       . $��2��6?   ��6I   Z� ��6_   Z� ��6v   Z� 6�   5      �� 5   
   -   5        $ txtPregunta��5   F   $��1��6   $��0��6"   $��20,32,20,157q�6/   $��14(�6r   ���	#FF010311
�������$��2��6�   ��6[   Z� 6�   �� 5!   
   -   5         ��Name$ listCajaRespuestas��5!   E   $��1��6   $��1��6#   $��20,37,20,10q�60   
���������6�   Z� 6�   � 5#   
   $��1��6   $��2��6$   $��Right=�61   $��
0,15,15,15q�6N   $��84��6b   .+�5$      �� -   5         ��Name$ btnSiguiente��5$      .��5%      �� $��/Imagen/topic_go_next.gif��6   $��25��6;   $��80��6G   6T   5&      5'      5)      5*      