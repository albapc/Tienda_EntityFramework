   M S B A M L   `   `   `  ����   TiendaInterfaz    TiendaInterfaz.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$	��350��$	��650��.���� .@��� $��Insertar datos��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��79* ��� $
��240* �.+��� -    ��Name$ lMarca��$��Marca��$
��Left=�$	��Top=�$��35(��� -   $ lTipoProducto��$��TipoProducto��$
��Left=�$	��Top=�$��35(� J� RenderTransformOrigin$ 1.914,0.667&�$��9,0,0,0q�$��1���� -   $ 	lProducto��$��Producto��$
��Left=�$	��Top=�$��35(�$ 1.914,0.667&�$��	283,0,0,0q�$��1���� $��Codigo:��$
��Left=�$��0,72,0,0q�$	��Top=��� $��Descripcion:��$
��Left=�$��	0,113,0,0q�$	��Top=��� -    ��Name$ CodigoMarca��$
��Left=�$��22�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$��93��$��	79,76,0,0q�$��2���� -   $ DescripcionMarca��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��
79,113,0,0q�$��2���� -   $��Insertar��$
��Left=�$	��Top=�$��75��$��
30,157,0,0q��� $��Codigo:��$
��Left=�$��	42,72,0,0q�$	��Top=�$��1���� -   $ CodigoTipoProducto��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��
119,76,0,0q�$��1���� $��Nombre:��$
��Left=�$��
42,113,0,0q�$	��Top=�$��1���� -   $ NombreTipoProducto��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��119,113,0,0q�$��1���� -	   $��Insertar��$
��Left=�$	��Top=�$��75��$��
83,157,0,0q�$��1���� $��MarcaId:��$
��Left=�$��
258,72,0,0q�$	��Top=�$��1���� $��TipoProductoId:��$
��Left=�$��
258,98,0,0q�$	��Top=�$��1���� $��Descripcion:��$
��Left=�$��258,120,0,0q�$	��Top=�$��1���� $��Talle:��$
��Left=�$��258,139,0,0q�$	��Top=�$ 0.528,0.385&�$��1���� $��Color:��$
��Left=�$��258,159,0,0q�$	��Top=�$��1���� $��Precio:��$
��Left=�$��258,180,0,0q�$	��Top=�$ 0.511,-0.077&�$��1���� $��Stock:��$
��Left=�$��258,199,0,0q�$	��Top=�$��1���� -
    ��Name$ comboBoxMarcaId��$
��Left=�$��22��$	��Top=�$��93��$��
364,76,0,0q�$��1���� -   $ comboBoxTipoProductoId��$
��Left=�$��22�� �� Text$  ��$	��Top=�$��93��$��
364,98,0,0q�$��1���� -   $ DescripcionProducto��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��364,120,0,0q�$��1���� -   $ comboBoxTalle��$
��Left=�$��22��$  ��$	��Top=�$��93��$��364,139,0,0q�$��1��.@��� .���� S�� .���� M�� .���� L�� .���� XL�� -   $ ColorProducto��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��364,159,0,0q�$��1���� -   $ PrecioProducto��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��364,181,0,0q�$��1���� -   $ StockProducto��$
��Left=�$��22��$
 Wrap=�$�� ��$	��Top=�$��93��$��364,203,0,0q�$��1���� -   $��Insertar��$
��Left=�$	��Top=�$��75��$��327,243,0,0q�$��1���� $��Consultar productos��.���� .+��� -   $ ��Listar todos los productos��$
��Left=�$	��Top=�$	��161��$��22�� �� Left$	 456��
	 �� Top$		 238���� $��Buscar producto por:��$
��Left=�$	��Top=�$	 362��$	 10��$ -0.025,0.154&��� -   $ 	comboBox1��$	 497��$	 14��$	��120��.@��� .���� 
ProductoId�� .���� 	MarcaId�� .���� TipoProductoId�� .���� Descripcion�� .���� Talle�� .���� Color�� .���� Precio�� .���� Stock�� -   $ 
tbProducto��$
��Left=�$��24��$
 Wrap=�$�� ��$	��Top=�$	��120��$	 363��$	 51���� -   $��Buscar��$
��Left=�$	��Top=�$��64��$��26��$	 497��$	 51���� -   $��Generar ticket��$
��Left=�$	��Top=�$	��161��$��22��$	 262��$		 238��&   System.Windows.Controls.DataGrid  -   
  Name$
 datag��$	��200��$	��340��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
ProductoId��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ProductoId+  $ MarcaId�� �� *	MarcaId+  $ TipoProductoId�� �� *TipoProductoId+  $ Descripcion�� �� *Descripcion+  $ Talle�� �� *Talle+  $ Color�� �� *Color+  $ Precio�� �� *Precio+  $ Stock�� �� *Stock+