   M S B A M L   `   `   `  ���� D  @TotalStat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TotalStat	TotalStat      TotalStat.AppWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:TotalStat       � Title$  	AppWindow��
 � Top ��  �� Path$* $(local:AppSizeGeometry.AppWindowTop)� �� Mode$ TwoWay=� � Left �� $+ %(local:AppSizeGeometry.AppWindowLeft)�$ TwoWay=����� $- '(local:AppSizeGeometry.AppWindowHeight)�$ TwoWay=� �� FallbackValue$	 450������ $, &(local:AppSizeGeometry.AppWindowWidth)�$ TwoWay=�$	 450�� � 	Resources    
pointerImg  linkImg  businessImg)   #TotalStat.SetDataGridColorConverter  DeltaConvDataGrid   
BlackBrush   DarkRedBrush	   DarkGreenBrush#   TotalStat.ReportShowConverter  ReportShowConv
   DarkRedBrush   DarkGreenBrush   DarkBlueBrush   DefaultBrush%   TotalStat.DividendShowConverter  DividendShowConv   
BlackBrush   DefaultBrush'   !TotalStat.ReportInSectorConverter  ReportInSectorConv   DarkRedBrush   DefaultBrush  
DeltaStyle �� 
TargetType �� Property �� Value �� 	Converter  NiteFirstStyle 	 NiteSecondStyle 
 ReportShowStyle  DividendShowStyle  ReportInSectorStyle��%�  &	        &	      &	 7     &	 U     &	 �     &	 �     &	 �     &	 �     7  &	 W    7  &		 �    7  &	
 &    7  &	 �    7  &	 �    7  �� $��Image/pointer.png���� $��Image/link.png���� $��Image/business.png��  $ Black��$ DarkRed��$	 	DarkGreen��  $
 DarkRed��$ 	DarkGreen��$ DarkBlue�� Z�   $ Black�� Z�   $ 	#FFE57A56�� Z� �� " ��.���  � �� �� $ 	DeltaNite�8   ��  �@��TextAlignment$ Center=��� " ��.���  � �� �� $ FirstNitePercent�8   ��  �@��TextAlignment$ Center=��� " ��.���  � �� �� $ SecondNitePercent�8   ��  �@��TextAlignment$ Center=��� " ��.���  � �� �� $ ReportForView�8   ��  �@��TextAlignment$ Center=��� " ��.���  � �� �� $ 
DivForView�8   ��  �@��TextAlignment$ Center=��� " ��.���  � �� �� *Ticker+8   ��  �@��TextAlignment$ Center=�.��� $��2q� � RowDefinitions �� $
��0.2* ��� $
��0.2* ��� $��0.13* ��� .+�� $��0��$��2q� � DataContext �� *Desc+ �� ��  � ColumnDefinitions �� �� �� �� .+�� $��0��$��0��$��4��$��2�� �� $��0.35* ��� $��* ��� $
��0.6* ��� $
��0.6* � �� �� .+��� $��0��$��0��$��12(�$
��Bold"�$��	Underline{����� *Ticker+$ Ticker���� $��0��$��1��$��11(�$��Italic$�$��2q����� *CompanyName+$ CompanyName����  �� Orientation$ 
Horizontal=�$��0��$��2��$��2q�.+��� $��MCap: ��$��11(��� $
��Bold"�$��11(����� *	MarketCap+$ 0���� $��b��$
��Bold"�$��11(��� $ 
Horizontal=�$��0��$��3��$��2q�.+��� $��SFloat: ��$��11(��� $
��Bold"�$��11(����� *
ShortFloat+$ 0���� $��%��$
��Bold"�$��11(��� $��1��$��0��$��11(�$
��Bold"�$��2q����� *	Country+$ Country���� $��1��$��1��$��11(�$��Italic$�$��2q����� *
Industry+$ Industry���� $��1��$��2��$��11(�$��	Underline{�$��2q����� *Sector+$ Sector���� $ 
Horizontal=�$��1��$��3��$��2q�.+��� $��AvgVol: ��$��11(��� $��11(�$
��Bold"����� *AvarageVolume+$ 0���� $��m��$��11(�$
��Bold"�� $��1��$��2q� �� ��  �� �� �� .+��� $ 
Horizontal=�$��0��$��0��.+��� $��Beta: ��$��11(��� $��11(�$
��Bold"����� *Beta+ �� StringFormat$
 0.00��$ 0���� $ 
Horizontal=�$��0��$��1��.+��� $��Correlation: ��$��11(��� $��11(�$
��Bold"����� *Correlation+$
 0.00��$ 0���� $ 
Horizontal=�$��1��$��0��.+��� $��HvBeta: ��$��11(��� $��11(�$
��Bold"����� *HvBeta+$
 0.00��$ 0���� $ 
Horizontal=�$��1��$��1��.+��� $��AvgPremVol: ��$��11(��� $��11(�$
��Bold"����� *
AvgPremVol+$ 0���� $ 
Horizontal=�$��0��$��3��$��2��$��Center=�.+��� $��15��$��35��$��7q�#��[ ���� *BusinessShowCommand+ � ToolTip _� .��Stock businness�� $��15��$��35��$��7q�#��[ ���� *	LinkStart+ _� .��Link� $��2�� �� �� �� $
��0.8* �.+��� $��0��$��2��$ 
Horizontal=�.+��� -    ��Name$ FirstStockTextBox��$��80��$��5,5,1,5q� �� CharacterCasing$ Upper=����� *FirstStockTextBoxString+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.���� $��20��$��0,5,1,5q�#��[  ���� *ReportAddFromAppCommand+ _� .��Add to today reports�� -   $ SecondStockTextBox��$��80��$��5q�$ Upper=����� *SecondStockTextBoxString+$ TwoWay=�$ PropertyChanged=�.���� $ 
Horizontal=�$��0��$��3��$��2��.+��� -    ��Name$ 
ReportShow��$��10��$��35��$��5q�$
��Bold"�  �� TextAlignment$  Center=�$��Center=�#��[
 
����������� *ReportForView+$	 Rep�� �� .+��� YY-day before yesterday�� Y - yesterday�� 	A - today�� T - tomorrow�� BO - before open�� AC - after close�� -   $ DividendShow��$��10��$��35��$��5q�$��Center=�$
��Bold"�$  Center=�#��[ 
���  ������ *
DivForView+$	 Div�� �� 42Наличие дивидендов сегодня� $��3�� �� �� $
��0.3* �.+�&   System.Windows.Controls.DataGrid  $��0��!   
IsReadOnly! . "   AutoGenerateColumns" .  ��. $
��Auto=�$
��Auto=�#   	RowHeight$# 20Q�$��Center=�$��Center=����� $ DataGridView�$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   Header$
% Date��&   Width5  /System.Windows.Controls.DataGridLengthConverter$
& 0.6* '   FontSize$' 11Q�(   
FontWeight$
( Bold"�1	  +System.Windows.Controls.DataGridBoundColumn) 	  Binding) �� *Date+$ 
dd.MM.yyyy��* 	  ElementStyle* �� " ��.���  � ��$ Center=�  $' 11Q�$
( Bold"�$& 0.35* #* [ ) �� *FirstNitePercent+$
 0.00��% �� ���� + �� ElementName$+ FirstStockTextBox��$
 Text�  $' 11Q�$
( Bold"�$& 0.35* #* [	 ) �� *SecondNitePercent+$
 0.00��% �� ���� $+ SecondStockTextBox��$
 Text�  $% Delta��$' 11Q�$
( Bold"�$& 0.35* #* [ ) �� *	DeltaNite+$
 0.00��  $% PremVol��$' 11Q�$
( Bold"�$
& 0.5* ) �� *FirstPremVol+* �� " ��.���  � ��$ Center=��� $��1��.+��� 
���   �$��	3,-1,3,-1q����� $��8(�$
��Bold"����� *FirstSectorName+$ Sector 1��.���� $
��Left=����� $ FirstSectorForView����� .R��� #��[ $��8(�$��	2,-1,2,-1q����� *Ticker+�� 
���   �$��	2,-1,3,-1q����� $��7(�$
��Bold"����� *SecondSectorName+$ Sector 2��.���� $
��Left=����� $ SecondSectorForView����� .R��� #��[ $��8(�$��	2,-1,2,-1q����� *Ticker+�� 
���   �$��	2,-1,3,-1q����� $��7(�$
��Bold"����� *ThirdSectorName+$ Sector 3��.���� $
��Left=����� $ ThirdSectorForView����� .R��� #��[ $��8(�$��	2,-1,2,-1q����� *Ticker+