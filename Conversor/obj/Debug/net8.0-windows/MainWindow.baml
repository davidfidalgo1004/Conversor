   M S B A M L   `   `   `  ����D  @Conversor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Conversor	Conversor  5   	       Conversor.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Conversor     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��400��6+    � 
ResizeMode$ NoResize=�6:   $	��350��6P   $	��350��6`   .��5	      � .+�5
   
   o� $��Center=�6   $��32��6,   $	��Top=�68   $	��400��6P   .@�5      m� $��   Sobre��6   $��34��6)   $��97��65   .@�5      m� -   5         m�Name$ PropProg��5      $!��Propriedades do programador��6-   $
��Left=�6R   5      5      5      �� 5   
   -   5         ��Name$ cbTipoConversao��5      $
��Left=�6,   $��	30,60,0,0q�6G   $	��Top=�6Z   $	��120��6r   .@�5      �� ${�False��6   �� 5      $��Tempo��6   �� 5      $��Moeda��6   �� 5      $��Energia��6   �� 5      $��Comprimentos/Distâncias��6   5      �� 5   
   $
��Left=�6   $��	41,39,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   �� 6o    � Language$ pt-pt�6s   $�Tipo de Conversão��6�   6�   �� 5   
   -   5        $
 cbDE��5      $
��Left=�6!   $��
30,120,0,0q�6<   $	��Top=�6P   $	��120��6h   6t   �� 5   
   $
��Left=�6   $��	30,99,0,0q�6/   $
��Wrap=�6B   $	��De:��6V   $	��Top=�6a   �� 5   
   $
��Left=�6   $��
233,99,0,0q�6/   $
��Wrap=�6C   $��Para:��6W   $	��Top=�6d   �� 5   
   -   5        $ cbPARA��5      $
��Left=�6#   $��233,120,0,0q�6>   $	��Top=�6S   $	��120��6k   6w   �� 5   
   $
��Left=�6   $��
58,174,0,0q�6/   $
��Wrap=�6C   $��Valor a converter:��6W   $	��Top=�6q   �� 5   
   -   5         ��Name$ tbValorConverter��5      $
��Left=�6,   $��173,174,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $��Introduza o valor��6p   $	��Top=�6�   $	��120��6�   6�   �� 5   
   $
��Left=�6   $��
58,215,0,0q�6/   $
��Wrap=�6C   $��Valor convertido:��6W   $	��Top=�6p   �� 5    
   -   5        $ tbValorConvertido��5       $
��Left=�6-    �� 
IsReadOnly$
 True��6H   $��173,214,0,0q�6Z   $
 Wrap=�6o   $�� ��6�   $	��Top=�6�   $	��120��6�    �� IsReadOnlyCaretVisible$
 True��6�   �� 5!   
   -   5        	 ��Name$	 textConverter��5!      $
��Left=�6+   $��304,174,0,0q�6F   $
��Wrap=�6[   $�� ��6o   $	��Top=�6w   �� 5"   
   -   5        $	 textConvertido��5"      $
��Left=�6,   $��304,216,0,0q�6G   $
��Wrap=�6\   $�� ��6p   $	��Top=�6x   �� 5#   
   -	   5        $	 tbErroConvertido��5#      $��Center=�6.   $��	0,237,0,0q�6K   $
��Wrap=�6^   $�� ��6r   $	��Top=�6z   ���	#FFFC0A0A6�   5%      5&      