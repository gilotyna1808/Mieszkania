   M S B A M L   `   `   `  ����E  AMieszkania, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Mieszkania.UsuwanieMieszkania.Usuwanie  5      &     Mieszkania.Usuwanie.UsunRachunek   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Mieszkania.Usuwanie     5      .��5	      � ���#f6f6f6.+�5
   
   �� $��ID Rachunku��6   ���#2EC4B6$
��Left=�6B   $��40��6]   $��	45,55,0,0q�6i   $	��Top=�6|   $��15(�6�   $	��140��6�   �� 5   
   $��ID Umowy��6   ���#FF9F1C$
��Left=�6B   $��40��6]   $��
45,100,0,0q�6i   $	��Top=�6}   $��15(�6�   $	��140��6�   �� 5   
   $��Kwota��6   ���#2EC4B6$
��Left=�6B   $��40��6]   $��
45,145,0,0q�6i   $	��Top=�6}   $��15(�6�   $	��140��6�   �� 5   
   $��Termin Rozliczenia��6   ���#FF9F1C$
��Left=�6B   $��40��6]   $��
45,190,0,0q�6i   $	��Top=�6}   $��15(�6�   $	��140��6�   �� 5   
   $��	Opłacony��6   ���#2EC4B6$
��Left=�6B   $��40��6]   $��
45,235,0,0q�6i   $	��Top=�6}   $��15(�6�   $	��150��6�   �� 5   
   -   5          ��Name$  
txt_idrach��5      ���#FF9F1C$
��Left=�6B   $��40��6]   $��
190,55,0,0q�6i    �� TextWrapping$
 Wrap=�6~   $��Center=�6�   $	��Top=�6�   $	��240��6�   {�.  6�   �� 5   
   -   5        $  txt_id��5      ���#FF9F1C$
��Left=�6B   $��40��6]   $��190,100,0,0q�6i   $
 Wrap=�6~   $��Center=�6�   $	��Top=�6�   $	��350��6�   {�.  6�   �� 5   
   -   5        $  	txt_Kwota��5      ���#FF9F1C$
��Left=�6B   $��40��6]   $��190,145,0,0q�6i   $
 Wrap=�6~   $��Center=�6�   $	��Top=�6�   $	��350��6�   {�.  6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
txt_termin��5      ���#FF9F1C$
��Left=�6B   $��40��6]   $��190,190,0,0q�6i   $��Center=�6~   $	��Top=�6�   $	��350��6�   �� 5   
   -   5         ��Name$ cbox_oplacone��5      ���#FF9F1C$
��Left=�6B   $��40��6]   $��192,235,0,0q�6i   $	��Top=�6~   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�    �� SelectedValuePath$	 Key��6�    �� DisplayMemberPath$ Value��6�   $	��350��6�   �� 5   
   -   5         ��Name$ btn_wybierzrach��5      $��Wybierz rachunek��6*   $
��Left=�6E   $��40��6`   $��
440,55,0,0q�6l   $	��Top=�6�   
����������#FFBF69$	��100��6�   6�   �� 5   
   -   5        $ btn_usun��5      $��Usuń��6#   
����������#2EC4B6$��20(�6Z   $��Center=�6h   $��50��6�   $��340,400,0,0q�6�   $	��Top=�6�   $	��200��6�   6�   5      5      