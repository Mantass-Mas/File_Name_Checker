   M S B A M L   `   `   `  ����L  HFile_Name_Checker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:File_Name_CheckerFile_Name_Checker  5   	   "    File_Name_Checker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:File_Name_Checker     5   	     � Title$  ファイルチェック��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ inputFolder��5
      $=��7ここにフォルダをDrag and Dropしてください��6a   $	��Top=�6�   $
��Left=�6�   $	��100q�6�    �� TextWrapping$
 Wrap=�6�   $��15(�6�   $	��250��6�   $	��100��6�   �� 5   
   -   5        $ 	inputFile��5      $=��7ここにファイルをDrag and Dropしてください��6_   $	��Top=�6�   $��Right=�6�   $	��100q�6�   $
 Wrap=�6�   $��15(�6�   $	��250��6�   $	��100��6�   �� 5   
   -   5         ��Name$ check��5      $��Check Start��6    $	��100��66   $��50��6B   $��Bottom=�6N   $��Right=�6i   $��250, 50q�6�   6�   �� 5   
   -   5        $ finish��5      $��Finish��6!   $	��100��62   $��50��6>   $��Bottom=�6J   $
��Left=�6e   $��250, 50q�6�   6�   5      5      