   M S B A M L   `   `   `  ����   POEPart3    POEPart3.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Recipe App��$	��800��$	��800��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Recipes��$��0��$��10q�.���� .+���  �� Orientation$ 
Horizontal=�$��0,0,0,5q�.+��� $��Recipe Name:��$��Center=��� -    ��Name$ txtRecipeName��$	��200��$��5q��� -   $��
Add Recipe��$��5q��� $��Scale Recipe by:��$��Center=��� -   $ txtScale��$	��100��$��5q��� -   $��Scale Recipe��$��5q��� -   $��
Clear Data��$��5q��� -    ��Name$ 	lvRecipes��$	��0,5q� �� View �� .P��� $��Recipe Name�� �� DisplayMemberBinding �� *Name+� $��1��$��10q� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Ingredients��$��0��.���� .+��� $��Ingredient Name:���� -   $ txtIngredientName��$	��150��$��5q��� $��	Quantity:���� -   $ txtIngredientQuantity��$	��150��$��5q��� $��Measurement:���� -	   $ txtMeasurement��$	��150��$��5q��� $��	Calories:���� -
   $ txtCalories��$	��150��$��5q��� $��Food Group:���� -    ��Name$ txtFoodGroup��$	��150��$��5q�.@��� $��
Vegetables���� $��Fruits���� $��Grains���� $��Proteins���� $��Dairy���� $��Fats and Oils���� $��Other���� -   $��Add Ingredient��$��5q��� $��Recipe Details��$��1��.���� .+��� $��Selected Recipe:���� -   	 ��Name$	 txtSelectedRecipe��$��5q��� $��Total Calories:���� -   $	 txtTotalCalories��$��5q��� $��Ingredients:���� -   $ lvIngredients��$	��0,5q� �� .P��� $
��Name�� �� *Name+�� $��Quantity�� �� *
Quantity+�� $��Measurement�� �� *Measurement+�� $��Calories�� �� *
Calories+�� $��
Food Group�� �� *	FoodGroup+�� $��Recipe Steps��$��2��.���� .+��� $��Steps:���� -   
 ��Name$
 lbSteps��$��5q����� .R��� $ 
Horizontal=�.+���  d� 	IsChecked �� *IsCompleted+���� *Step+�� $��	Add Step:���� -   $ txtStep��$	��200��$��5q��� -   $��Add Step��$��5q��� $��Filter Recipes��$��2��$��10q�.���� .+��� $��Ingredient Name:���� -   $ txtFilterIngredientName��$	��200��$��5q��� $��Food Group:���� -   $ txtFilterFoodGroup��$	��200��$��5q��� $��Maximum Calories:���� -   $ txtFilterMaxCalories��$	��200��$��5q��� -   $��Filter��$��5q�