   M S B A M L   `   `   `  ����E  AMeteorChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MeteorChat.MVVM.ViewModelsMeteorChat.MVVM.ViewModels  5      E'clr-namespace:MeteorChat.CustomControlsMeteorChat.CustomControls  5      ,    &MeteorChat.CustomControls.Conversation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >	viewmodel(clr-namespace:MeteorChat.MVVM.ViewModels     5      9local'clr-namespace:MeteorChat.CustomControls     5      $
��Auto��5	      $
��Auto��5
        � 	Resources  5         MessageTextStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value  ItemTemplate �� 
TargetType ��Name	 �� CornerRadius
 �� Padding J� SnapsToDevicePixels � RowDefinitions � ColumnDefinitions ��Name 	 reply  IconButtonStyle �� Triggers �� 
TargetName P� Property P� Value��%�  &	        &	 |    7   7  7  �� 5   
   " ��6)   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 20q�6'   �� 5       � ��
 �   �6+   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$
 Wrap=�6-   �� 5       � �� 6%   �� *ReceivedMessage+ 5      �� 5       6   �� *IsMessageReceived+ True6D   .a�5      ��  � �� 6-   �� *ReceivedMessage+5      �� 5       6   �� *IsMessageReceived+	 False6D   .a�5      ��  � �� 6-   �� *SentMessage+5      5      �� 5    
   .R�5!      �� ��5"      �� 5#      " ��6   .�5$      ��  �@J�SnapsToDevicePixels . 6@   �� 5%       � ��$
 Auto��63   �� 5&       � ��$	 4,1q�64   �� 5'       � ��$ 10q�63   �� 5(       � ��$ Center=�6G   �� 5)       � ��$ Center=�6E   �� 5*       � ��$ Center=�6>   �� 5+       � ��
 ���� 67   �� 5,       � ��$ 0q�6<   �� 5.       � �� 5/      �� 50   "   " ��62   .R�51   &   �� $ border��58      #��z��52      #��z��53      #��z��54      $	 20��55      #
 z��56       . ._�5:   *   �  5;   .   �� 5=   2   $
��Auto �6@   �� 5?   2   �� 5B   2   $
��Auto �6@   .+�5D   .   �  5E   2   �� 5H   6   $
��Auto �6G   �� 5K   6   �� 5N   6   $
��Auto �6G   .+�5R   2   �� $��1��5S   5   $
��Auto��5T   5   $��60��5U   5   $
��Auto��5V   5   $��Center=�5W   5   ��5Y   6   �� 5[   :   " ��6@   .�5]   >   ��  �@��CornerRadius$ 
30,30,30,0��6]   �� 5^   >    � �� �#dce1de6[   �� 5_   >    � ��$
 Left=�6d    5`   >   �� 5a   B    6N   �� *IsMessageReceived+	 False6t   .a�5b   F   ��  �@��CornerRadius$ 
30,30,0,30��6e   �� 5c   F    � �� �#49a0786c   �� 5d   F    � ��$ Right=�6l   5e   C   5g   ;   ._�5l   6   ]� $	��700��5m   -   .+�5n   :   �� 8��  5o   1   5p   7   5q   3   �� 5t   2   $ ReplyButton��5u   5   8�� $y�	Collapsed=�5w   5   $��2��5x   5   8�� 5z   5   5{   /   �� 5~   .   $��2��5   1   ��5�   2   �� 5�   6   " ��6<   .�5�   :   ��  � ��$ Center=�6^   �� 5�   :    � ��$ 	0,10,20,0q�6S    5�   :   �� 5�   >    6J   �� *IsMessageReceived+ True6p   .a�5�   B   ��  � �� 6Y   �� *MsgReceivedOn+�� 5�   B    � ��$
 Left=�6h   5�   ?   �� 5�   >    6J   �� *IsMessageReceived+	 False6p   .a�5�   B   ��  � �� 6Y   �� *	MsgSentOn+�� 5�   B    � ��$ Right=�6h   5�   ?   5�   7   5�   /   5�   +   5�   '    5�   &   �� 5�   *   $ False��6\    66   �� *IsMessageReceived+.a�5�   .   �� $ ReplyButton��65    � ��$ 0��6e   5�   +   P� 5�   *    �@J�IsMouseOver . . �5�   .   �� $ ReplyButton��65    � y�$ Visible=�6d   5�   +   5�   #   5�      5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $
��Auto �6   �� 5�      .+�5�   
   �� -   5        $ searchBoxBorder��5�      ���#dce1de$	 15��5�      $��20q�5�      $��50��5�       +� FocusedElement 5�      ��  �� ElementName$ searchQuery��._�5�      �� -   5         ��Name$ searchQuery��5�      $��12, 0q�5�      
������ $��0q�5�      $��Center=�5�      $��Stretch=�5�      ��5�      �� *ConversationFilter+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5�   -   5�      5�      �� 5�   
   
�������$��Disabled=�5�      $��1��5�      .��5�      �� #��[ 5�      $��15,0,0,0q�5�      ��5�      �� *ConversationsCollectionView+$ PropertyChanged=���5�      �� 5�      .R�5�      �� 5�      5�      5�      5�      5�      