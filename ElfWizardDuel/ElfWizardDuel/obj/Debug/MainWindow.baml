   M S B A M L   `   `   `  ����H  DElfWizardDuel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ElfWizardDuelElfWizardDuel  5   	       ElfWizardDuel.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ElfWizardDuel     5   	   -   5          �Name$  MainForm��5   	    � Title$ 
MainWindow��5   	   $	��500��6   $	��900��6)    � 
ResizeMode$ NoResize=�65    � 	Resources 5	       �� 
TargetType   ButtonStyle �� Property �� Value �� 	Resources �� Triggers	 P� Property
 P� Value  Button1 �� BasedOn  WizardButton  FightAgainButton  Button2  	ElfButton  
DiceButton  
LabelStyle  	MainLabel 	 MainSecondLabel 
 
PointLabel  WizardPointLabel  WizardPoint  ElfPointLabel  ElfPoint  
ImageStyle  	DiceImage��%�  &	        &	     7   &	 h    7  &	 �    7  &	     7   &	 \    7  &	 �    7   &	 '    &	 h    7  &		 �    7  &	
 �
    7  &	 q    7 
 &	 �    7 
 &	 g    7 
 &	 �    7 
 &	 ^    &	 N    7  �� 5   
   " ��6   .�5      ��  � �� �#2125296+   �� 5       � ��
 �����6+   �� 5       � ��$ Showcard Gothic)�6+   �� 5       � ��$ Center=�64   �� 5       � ��$
 18px(�6)   �� 5       � ��$ 40��6'   �� 5       � ��$	 150��6&    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5,5,5,5��65   5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��
 �   �63   �� 5       �@�Cursor$
 Hand��6/   5      P� 5      	 �@�Tag$
 Hidden��6)   . �5      ��  � y�$ Hidden=�63   5      P� 5       	 �@�Tag$
 Visible��6)   . �5!      ��  � y�$ Visible=�63   5"      5$      �� 5&   
   " ��6   8   .�5'      ��  � ��$ 280,410,0,0q�6'   5(      �� 5*   
   " ��6   8   .�5+      ��  � ��
 �p�6+   5,      �� 5.   
   " ��6   8   .�5/      ��  � ��
 �  ��6+   50      �� 52   
   " ��6   8   .�53      ��  � ��$ 450,410,0,0q�6'   54      �� 56   
   " ��6   8   .�57      ��  � ��
 �"�"�6+   58      �� 5:   
   " ��6   8   .�5;      ��  � ��
 �  ��6+   �� 5<       � ��$ 375,185,0,0q�6'   5=      �� 5?   
   " ��6   .�5@      ��  � ��
 �   �6+   �� 5A       � ��$ Showcard Gothic)�6+   �� 5B       � ��$ Normal"�6+   �� 5C       � ��$ Center=�64   �� 5D       � ��$ Center=�62    5E      ���� 5F      '��       " ��6   .�5G      ��  �@��CornerRadius$ 5,5,5,5��65   5H      5I       5J      P� 5K      	 �@�Tag$
 Hidden��6)   . �5L      ��  � y�$ Hidden=�63   5M      P� 5N      	 �@�Tag$
 Visible��6)   . �5O      ��  � y�$ Visible=�63   5P      5R      �� 5T   
   " ��6   8   .�5U      ��  � ��$ 30(�6)   �� 5V       � ��$ 	100,0,0,0q�6'   5W      �� 5Y   
   " ��6   8   .�5Z      ��  � ��$ 30(�6)    5[      P� 5\      	 �@�Tag$
 Starter��6)   . �5]      ��  � ��
 �   �63   �� 5^       � ��
 ���� 63   �� 5_       � ��$ 
250,40,0,0q�6/   �� 5`       �@J�Opacity$ 1Q�60   5a      P� 5b      	 �@�Tag$
 Loser��6)   . �5c      ��  � ��
 �  ��63   �� 5d       � ��
 �����63   �� 5e       � ��$ 100,170,0,0q�6/   �� 5f       �@J�Opacity$	 0.8Q�60   5g      P� 5h      	 �@�Tag$
 Winner��6)   . �5i      ��  � ��
 � � �63   �� 5j       � ��
 �   �63   �� 5k       � ��$ 130,170,0,0q�6/   �� 5l       �@J�Opacity$	 0.8Q�60   5m      5o      �� 5q   
   " ��6   8   .�5r      ��  � ��$ 25(�6)   �� 5s       � ��
 �����6+   �� 5t       �@J�Opacity$	 0.8Q�6(   5u      �� 5w   
   " ��6   8   .�5x      ��  � ��$ 	30,60,0,0q�6'   5y      �� 5{   
   " ��6   8   .�5|      ��  � ��$ 120,110,0,0q�6'   �� 5}       � ��
 �p�6+   �� 5~       � ��
 �����6+   5      �� 5�   
   " ��6   8   .�5�      ��  � ��$ 
600,60,0,0q�6'   5�      �� 5�   
   " ��6   8   .�5�      ��  � ��$ 700,110,0,0q�6'   �� 5�       � ��
 �"�"�6+   �� 5�       � ��
 �����6+   5�      �� 5�   
   " ��6    5�      P� 5�      	 �@�Tag$
 Hidden��6)   . �5�      ��  � y�$ Hidden=�63   5�      P� 5�      	 �@�Tag$
 Visible��6)   . �5�      ��  � y�$ Visible=�63   5�      5�      �� 5�   
   " ��6   8   .�5�      ��  � ��$ 90��6'   �� 5�       � ��$ 90��6&   �� 5�       � ��$ 
405,80,0,0q�6'   5�      5�      .��5�      � -   5         �Name$ MainGrid��5�      $	��900��6   $	��500��6)   .+�5�   
   �� -   5         ��Name$ canvas��5�      $	��900��6!   $	��500��6-    J� 	AllowDrop . .+�5�      �� -   5         ��Name$ 	mainLabel��5�      #��[ 6'   6L   �� 5�      -   5        $ mainSecondLabel��5�      #��[	 6-   6X   �� 5�      -   5        $ elfLifePointsLabel��5�      #��[ 60   6Y   �� 5�      -   5        $ elfLifePoints��5�      #��[ 6+   6O   �� 5�      -   5        $ wizardLifePointsLabel��5�      #��[ 63   6_   �� 5�      -	   5        $ wizardLifePoints��5�      #��[ 6.   6U   �� 5�      -
   5         ��Name$ 	diceImage��5�      #��[ 6'   6L   �� 5�      -   5         ��Name$ button1��5�       K� ZIndex$ 1��6&   #��[ 6S   .��6y   WIZARD6�   �� 5�      -   5        $ button2��5�      $ 1��6&   #��[ 6S   .��6v   
ARCHER ELF6�   �� 5�      -   5        $ fightAgainButton��5�      $ 1��6/   #��[ 6`   .��6�   Fight Again6�   �� 5�      -   5        $ 
exitButton��5�      $ 1��6)   #��[ 6T   .��6u   Exit6{   �� 5�      -   5        $ 
diceButton��5�      $ 1��6)   #��[ 6;   .��6_   Roll the dice!6o   5�      5�      5�      