   M S B A M L   `   `   `  ����E  AMeteorChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MeteorChat
MeteorChat  5   	   G(clr-namespace:MeteorChat.MVVM.ViewModelsMeteorChat.MVVM.ViewModels  5   	   E'clr-namespace:MeteorChat.CustomControlsMeteorChat.CustomControls  5   	   &     MeteorChat.MVVM.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MeteorChat     5   	   >	viewmodel(clr-namespace:MeteorChat.MVVM.ViewModels     5   	   Bcustomcontrols'clr-namespace:MeteorChat.CustomControls     5   	   -   5          �Name$  
mainWindow��5
   	    � AllowsTransparency . 
������ $��15(�5   	   $	��768��5   	   $
��1250��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Meteor Chat��5   	    � DataContext 5      .   (MeteorChat.MVVM.ViewModels.MainViewModel  5   
    � 	Resources 5         ContactInfoButtonStyle �� 
TargetType	 �� Property
 �� Value  ContactInfoButtonTemplate �� 
TargetType � ColumnDefinitions j� Stretch �� ImageSource �� UpdateSourceTrigger��%P  &	        &	 �     �� 5   
   " ��6/   .�5      �� 	 � ��

 ���� 6+   �� 5      	 � ��

 ���� 6,   �� 5      	 � ��$
 0q�60   5      �� 5    
   " ��6<   .R�5!      �� #��z��5"      #��z��5#      #��z��5$      ._�5&      � $��Center=�6    5'      �� 5*      $��75 �6+   �� 5-      .+�50      A� $��40��51      $��40��52      ��53      �� 54      $ UniformToFill=�57       55      �� *ContactPhoto+$ PropertyChanged=�57      59      � 5;      $��1��5<      .+�5>      �� �� 5@      $
��Bold"�5B      $��20(�5C      �5A      �� *ContactName+$ PropertyChanged=�5C      �� 5D      �� 5G      $��15(�5I      �5H      �� *
LastSeen+$ PropertyChanged=�5I      5J      5K      5L      5M      5N      5O      .��5R      ��  �� CornerRadius$ 20��6   
�������._�5T   
   �  � RowDefinitions 5U      �� 5V      $
��Auto �6    �� 5W       5Y      �� 5\      $
��Auto �6#   �� 5_      �� 5b      $
��Auto �6#   .+�5g      �� ���#49a078$ 	20,20,0,0��5i      $��3��5j       J� InputBindings 5k      d� 5l       d� MouseAction$ 	LeftClicke�5m       �� Command 5n      �� *MoveWindowCommand+ �� CommandParameter 5o      ��  �� ElementName$ 
mainWindow��5p      d� 5r      $ LeftDoubleClicke�5s       5t      �� *MaximizeWindowCommand+ 5u      �� $ 
mainWindow��5v      ._�5x      � .+�5y      �� $
��Left=�5{      $
��15,0q�5|      $��Center=�5}      
�������$��22(�5      $
��Bold"�5�      ��5z      �� *Title+$ 
mainWindow��5�      �� 5�      $��Right=�5�      $��10, 0q�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� -   5         ��Name$ btnMinimize��5�   !     minimize#��[ 5�   !     IconButtonStyle#��[ 5�   !   ��5�   !   �� *MinimizeWindowCommand+��5�   !   �� $ 
mainWindow��5�   !   �� 5�      -   5        $ btnMaximize��5�   !     maximize#��[ 5�   !   #��[ 5�   !   ��5�   !   �� *MaximizeWindowCommand+��5�   !   �� $ 
mainWindow��5�   !   �� 5�      -   5        $ btnClose��5�   !    	 close#��[ 5�   !   
���  ��#��[ 5�   !   ��5�   !   �� *CloseWindowCommand+5�   !   5�      5�      5�      � 5�      $��1��6   $	��406��6     5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      .+�5�      � $��75��5�      $
��15,0q�5�       5�      �� 5�      $
��Auto �6+   �� 5�      �� 5�      $��40 �6+   �� 5�      $��40 �6+   .+�5�      �� $��Chats��5�      $
��Left=�5�      $��Center=�5�      $��20(�5�      $��SemiBold"�5�      �� 5�      -   5        $ ChatSearchButton��5�      $��2��5�       
 search#��[ 5�      #��[ 5�      d� 5�      -   5         d�Name$ btnMoreOptions��5�      $��3��5�        more#��[ 5�        ToggleIconButtonStyle#��[ 5�      5�      �� 5�      -   5         ��Name$ searchBoxBorder��5�      ���#dce1de$ 15��5�      $��1��5�      $��20q�5�      $��50��5�       +� FocusedElement 5�      �� $ searchQuery��._�5�      �� -   5         ��Name$ searchQuery��5�      $��12, 0q�5�      
������ $��0q�5�      $��Center=�5�      $��Stretch=�5�      ��5�      �� *ChatsFilter+ �� Mode$ TwoWay=�$ PropertyChanged=�5�   7   5�      ,   &MeteorChat.CustomControls.StatusThumbs  5�      $��2��6.   (   "MeteorChat.CustomControls.ChatList  5�      $��3��6*   5�      � 5�      $��1��6   $��1��5�       5�      �� 5�      $
��Auto �6$   �� 5�      �� 5     $
��Auto �6$   �� 5     $
��Auto �6$   .+�5     � $��75��5     $��0,0,15,0q�5	     $��Center=�5
      5     �� 5     �� 5     $��50 �6+   �� 5     $��50 �6+   �� 5     $��50 �6+   �� 5     $��50 �6+   .+�5     �� #��[  5     #��[ 5     �� 5"      	 	videocall#��[	 5#     $��1��5$     #��[ 5%     �� 5(      
 call#��[
 5)     $��2��5*     #��[ 5+     �� 5.     #��[ 5/     $��3��50     #��[ 51     �� 54     #��[ 55     $��4��56     #��[ 57     58     ,   &MeteorChat.CustomControls.Conversation  5<     $��1��6.   � 5?     $��3��6   .+�5@     �� $ 15��5A     ���#dce1de$��50��5C     $
��15,8q�5D     ._�5E     �  5F     �� 5I  "   �� 5K  "   $
��Auto �63   .+�5N     �� -	   5        $ 
MessageBox��5O  !   $
��12,0q�5P  !   $��0q�5Q  !   
������ $��Center=�5S  !   $��Stretch=�5T  !   ��5U  !   �� *MessageText+.��6>   .��5V  =   5W     �� 5Z     $ 
Horizontal=�5[  !   $��1��5\  !   .+�5_  "   �� -
   5        $ AttachButton��5b  %    
 attach#��[ 5`  %   #��[ 5a  %   5b  %   �� 5c  "   -   5        $ SendMsgButton��5f  %     send#��[ 5d  %   #��[ 5e  %   5f  %   5g     5h     5i     5j     5l     +   %MeteorChat.CustomControls.ContactInfo  5p     -   5          Name$ ContactInfoScreen��5q     $��1��5r     $��2��5s     5t     5u     5v     