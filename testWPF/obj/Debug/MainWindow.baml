   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5   	   B >testWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:testWPFtestWPF 5   	      testWPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:testWPF     5   	     � Title$  	projetWPF��5	   	   $	��450��6   $	��800��6(   $��80��5
   	   $	��300��6   .��5      � -   5         �Name$ 
gridGlobal��5       � RowDefinitions 5   
   �� 5      $��20 �6   $��20��6(   �� 5      $��30 �6   $��30��6(   �� 5      .+�5   
   o� -   5         o�Name$ MenuOptions��5      $	��Top=�6$   $��0��69   $��20��6F   .@�5      m� $
��File��6   .@�5      m� -   5         m�Name$ BouttonFileOpen��5      $
��Open��64   5      m� 5      -   5        $ BouttonFileSave��5      $
��Save��64   6B   m� 5      $	��POI��6   .@�5      m� -   5        $ BouttonImportPOI��5      $��Import��69   5      m� 5       -   5        $ BouttonExportPOI��5       $��Export��69   5"      5#      m� 5%      $��Trajet��6   .@�5&      m� -   5        $ BouttonImportTrajet��5&      $��Import��6<   5(      m� 5)      -   5        $ BouttonExportTrajet��5)      $��Export��6<   5+      5,      m� 5/      -	   5        $ BouttonFileExit��5/      $
��Exit��64   6B   51      m� 54      $��Tools��6   .@�55      m� $��Option��6   57      m� 58      $��	About box��6   5:      5<      5=      � 5A   
   -
   5        $ toolBar��5A      $��1��6    $��30��6-   ���	#FFEEF5FD � ColumnDefinitions 5B      �� 5C      $	��200 �6#   $	��200��6/   6@   �� 5D      $	��200 �6#   $	��200��6/   6@   .+�5H      `� $	��Top=�6   $��0��6/   .�5J      c� .@�5K      	� -   5         	�Name$ BouttonCreation��5K   "   $��Créer��6;   6k   	� 5L      -   5        $ BouttonModification��5L   "   $��Modifier��6?   6v   	� 5M      -   5        $ BouttonSuppression��5M   "   $��	Supprimer��6>   $��Bottom=�6R   6�   5N      5O      �� 5Q      $��0��6   $��Right=�6+    �� ShowsPreview . 
�������$��5��6m   6y   `� 5S      $	��Top=�6   $��1��6/   .�5U      c� .@�5V      	� -   5        $ 
BouttonPOI��5V   "   $	��POI��66   $��Bottom=�6D   6z   	� 5W      -   5        $ BouttonTrajet��5W   "   $��Trajet��69   6h   	� 5X      -   5        $ BouttonSurface��5X   "   $��Surface��6:   6k   5Y      5Z      5[      � 5\   
   $��2��6    5]      �� 5^      $	��200 �6#   61   �� 5_      6%   .+�5c      � -   5        $ gridListeData��5c      $��0��6*   $	��200��6:   
����  �$
��Left=�6X    5d      �� 5e      $��50 �6'   $��50��62   6B   �� 5f      $	��150 �6'   65   �� 5g      6)   .+�5k      �� -   5         ��Name$ 	stackType��5k      $��0��60   $
��Left=�6@   
���  ��$��50��6l   .+�5l      �� 
���   �$��2q�61   ._�5m      �� $
��type��6$   62   5n      5o      �� 5q      -   5        $ 	stackDesc��5q      $��1��60   $
��Left=�6@   
��� ���$	��150��6o   .+�5r      �� -   5        	 ��Name$	 gridSplitterDesc��5r      
���   �$��2q�6K   ._�5s      �� $��description��6$   $��Center=�67   6V   5t      5u      5w      '   !Microsoft.Maps.MapControl.WPF.Map  5y      -   5        
  Name$	
 Map��5y      $��1��6!   +   %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @Au1DwhMnLWyvsAbYS1Rq1idPj7mV6Z5i-oQ_Szgo2Mi1HysVM9QpAeeoBDQvr-Kp 61      Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 37.806029,-122.407007 6�      	ZoomLevel$ 18Q�6�      Mode;   5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$
 Road 6�   6�   5z      5{      5}      