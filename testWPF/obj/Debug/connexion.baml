   M S B A M L   `   `   `  ����B  >testWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:testWPFtestWPF  5   	       testWPF.connexion   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:testWPF     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&   .��5	      � 
��� ��� � RowDefinitions 5   
   �� 5      $	��330 �6   �� 5      .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   
���  ��.+�5      �� $��prenom :��6   
�������$��40��6?   $	��100��6K   $��25(�6W   $��10,20,10,20q�6e   6|   �� 5      $��nom :��6   
�������$��40��6<   $	��100��6H   $��25(�6T   $��10,20,10,20q�6b   6y   �� 5      $��mail :��6   
�������$��40��6=   $	��100��6I   $��25(�6U   $��10,20,10,20q�6c   6z   5      �� 5      $��1��6   
����  �.+�5      �� -   5         ��Name$ 	BoxPrenom��5      
�������$��40��6@   $	��100��6L   $��25(�6X   $��10,20,10,20q�6f   6}   �� 5      -   5        $ BoxNom��5      
�������$��40��6=   $	��100��6I   $��25(�6U   $��10,20,10,20q�6c   6z   �� 5      -   5        $ BoxMail��5      
�������$��40��6>   $	��100��6J   $��25(�6V   $��10,20,10,20q�6d   6{   5      5       �� 5"   
   -   5         ��Name$ BouttonValider��5"      $��1��6)   $��40��66   $	��100��6B   
�������$��valider��6a   $��25(�6s   6�   5#      5$      