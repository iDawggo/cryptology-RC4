   M S B A M L   `   `   `  ????H  DRC4 Algorithm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RC4_AlgorithmRC4_Algorithm  5   	       RC4_Algorithm.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:RC4_Algorithm     5   	     ? Title$  RC4 Algorithm??5   	   $	??500??6   $	??800??6,   .??5	      ? .+?5
   
   ?? $
??Left=?6   $??	10,25,0,0q?6/   $
??Wrap=?6B   $"??Keyword (Max 50 characters):??6V   $	??Top=?6z   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ inKey??5      $
??Left=?6!   $??16??6<   $??
183,25,0,0q?6H    ?? TextWrapping$
 Wrap=?6\   $	??Top=?6p   $	??310??6?    ?? 	MaxLength$ 50??6?   $??Consolas)?6?   ?? 5   
   $
??Left=?6   $??
10,100,0,0q?6/   $
??Wrap=?6C   $)??#Plaintext Input (Character Format):??6W   $	??Top=?6?   $
??Bold"?6?   ?? 5   
   $
??Left=?6   $	??100??62   $??
10,121,0,0q?6?   $	??Top=?6S   $	??385??6k   .??5      ?? -   5        $ scrllPlainInput??5      $
 Wrap=?6/   $?? ??6C   $??Consolas)?6s   5      ?? 5   
   $
??Left=?6   $??400,100,0,0q?6/   $
??Wrap=?6D   $,??&Ciphertext Input (Hexadecimal Format):??6X   $	??Top=?6?   $
??Bold"?6?   ?? 5   
   $
??Left=?6   $	??100??62   $??397,121,0,0q?6?   $	??Top=?6T   $	??382??6l   .??5      ?? -   5        $ scrllCipherInput??5      $
 Wrap=?60   $?? ??6D   $??Consolas)?6u   5      ?? 5   
   $
??Left=?6   $??	10,46,0,0q?6/   $
??Wrap=?6B   $	??Top=?6V   $
??Bold"?6n   $	??127??6?   ?? 6?   $?	Keystream??6?   ?? 6?   ?? 6?   $$?(Hexadecimal format, Read Only??6?   ?? 6?   $?):??6?   6?   ?? 5   
   -   5        $ outKey??5      $
??Left=?6"   $??
142,46,0,0q?6=   $
 Wrap=?6Q   $	??Top=?6e   $??49??6}   $	??351??6?   $??Consolas)?6?    ?? 
IsReadOnly . 6?   ?? 5   
   -   5         ??Name$ outPlainErrors??5      $
??Left=?6,   $??
10,352,0,0q?6G   $
??Wrap=?6[   $	??Top=?6o   $??70??6?   $	??385??6?   $
??Bold"?6?   
???  ??6?   ?? 5   
   -   5        $ outCipherErrors??5      $
??Left=?6-   $??397,352,0,0q?6H   $
??Wrap=?6]   $	??Top=?6q   $??70??6?   $	??382??6?   
???  ??$
??Bold"?6?   ?? 5   
   $
??Left=?6   $??
10,226,0,0q?6/   $
??Wrap=?6C   $8??2Ciphertext Output (Hexadecimal Format, Read Only):??6W   $	??Top=?6?   $
??Bold"?6?   ?? 5   
   $
??Left=?6   $	??100??62   $??
10,247,0,0q?6?   $	??Top=?6S   $	??385??6k   .??5      ?? -   5        $ scrllOutCipher??5      $
 Wrap=?6.   $?? ??6B   $??Consolas)?6J    . 6`   5      ?? 5   
   $
??Left=?6   $	??100??62   $??397,247,0,0q?6?   $	??Top=?6T   $	??382??6l   .??5      ?? -   5        $ scrllOutPlain??5      $
 Wrap=?6-   $?? ??6A   $??Consolas)?6I    . 6_   5      ?? 5   
   $
??Left=?6   $??397,226,0,0q?6/   $
??Wrap=?6D   $5??/Plaintext Output (Character Format, Read Only):??6X   $	??Top=?6?   $
??Bold"?6?   5       5!      