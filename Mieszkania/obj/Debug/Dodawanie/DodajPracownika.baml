   M S B A M L   `   `   `  ����E  AMieszkania, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Mieszkania
Mieszkania  5   	        Mieszkania.DodajPracownika   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Mieszkania     5   	   .��5	      � -   5        ���#f6f6f6.+�5
   
   �� $��Imie: ��6   ���#2EC4B6$
��Left=�6F   $��40��6a   $��	45,55,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��140��6�   �� 5   
   $��
Nazwisko: ��6   ���#FF9F1C$
��Left=�6F   $��40��6a   $��
45,100,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��140��6�   �� 5   
   $��Numer telefonu: ��6   ���#2EC4B6$
��Left=�6F   $��40��6a   $��
45,145,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��140��6�   �� 5   
   $��Pesel:��6   ���#FF9F1C$
��Left=�6F   $��40��6a   $��
45,190,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��140��6�   �� 5   
   $��Miasto zamieszkania:��6   ���#2EC4B6$
��Left=�6F   $��40��6a   $��
45,235,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��150��6�   �� 5   
   $��Adres zamieszkania:��6   ���#FF9F1C$
��Left=�6F   $��40��6a   $��
45,280,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��150��6�   �� 5   
   $��Stanowisko:��6   ���#2EC4B6$
��Left=�6F   $��30��6a   $��
45,320,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��140��6�   �� 5   
   $��Zatrudniony:��6   ���#FF9F1C$
��Left=�6F   $��30��6a   $��
45,360,0,0q�6m   $	��Top=�6�   $��15(�6�   $	��140��6�   �� 5   
   -   5          ��Name$  txt_imiePrac��5      ���#FF9F1C$
��Left=�6F   $��40��6a   $��
190,55,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��Top=�6�   $	��350��6�   6�   �� 5   
   -   5        $  txt_nazPrac��5      ���#FF9F1C$
��Left=�6F   $��40��6a   $��190,100,0,0q�6m   $
 Wrap=�6�   $��Center=�6�   $	��Top=�6�   $	��350��6�   6�   �� 5   
   -   5        $  txt_telPrac��5      ���#FF9F1C$
��Left=�6F   $��40��6a   $��190,145,0,0q�6m   $
 Wrap=�6�   $��Center=�6�   $	��Top=�6�   $	��350��6�   6�   �� 5   
   -   5        $  	txt_Pesel��5      ���#FF9F1C$
��Left=�6F   $��40��6a   $��190,190,0,0q�6m   $
 Wrap=�6�   $��Center=�6�   $	��Top=�6�   $	��350��6�   6�   �� 5   
   -   5        $  
txt_miasto��5      ���#FF9F1C$
��Left=�6F   $��40��6a   $��190,235,0,0q�6m   $
 Wrap=�6�   $��Center=�6�   $	��Top=�6�   $	��350��6�   6�   �� 5   
   -   5        $  	txt_adres��5      ���#FF9F1C$
��Left=�6F   $��40��6a   $��190,280,0,0q�6m   $
 Wrap=�6�   $��Center=�6�   $	��Top=�6�   $	��350��6�   6�   �� 5   
   -   5         ��Name$ cbox_stanowisko��5      $
��Left=�61   $��190,325,0,0q�6L   $	��Top=�6a   $	��350��6y   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�    �� SelectedValuePath$	 Key��6�    �� DisplayMemberPath$ Value��6�   $��33��6�   �� 5   
   -	   5        $ cbox_zatrudniony��5      $
��Left=�61   $��190,360,0,0q�6L   $	��Top=�6a   $	��350��6y   $
 TrueY�6�   $	 Key��6�   $ Value��6�   $��37��6�   �� 5   
   -
   5         ��Name$ 	btn_dodaj��5      $��Dodaj��6$   $
��Left=�64   
����������#2EC4B6$��20(�6w   $��Center=�6�   $��50��6�   $��340,400,0,0q�6�   $	��Top=�6�   $	��200��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataG��5      $
��Left=�6"   $��62��6=   $��-156,121,0,0q�6I   $	��Top=�6_   $��76��6w   $y�Hidden=�6�   5      5      