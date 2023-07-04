﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace POEPart3
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe selectedRecipe;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
            selectedRecipe = null;
            lvRecipes.ItemsSource = recipes;
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtRecipeName.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipe = new Recipe { Name = recipeName };
            recipes.Add(recipe);
            recipes = recipes.OrderBy(r => r.Name).ToList();
            lvRecipes.ItemsSource = recipes;
            lvRecipes.Items.Refresh();

            txtRecipeName.Text = string.Empty;

            // Set the newly added recipe as the selected recipe
            selectedRecipe = recipe;
            txtSelectedRecipe.Text = selectedRecipe.Name;
            lvIngredients.ItemsSource = selectedRecipe.Ingredients;
            lvIngredients.Items.Refresh();
            txtTotalCalories.Text = string.Empty;
        }
        
        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            string scaleText = txtScale.Text.Trim();
            if (string.IsNullOrEmpty(scaleText))
            {
                MessageBox.Show("Please enter a scale value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (double.TryParse(scaleText, out double scale))
            {
                // selectedRecipe.ScaleIngredients(scale);
                lvIngredients.Items.Refresh();

            }
            else
            {
                MessageBox.Show("Invalid scale value. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
       


        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string ingredientName = txtIngredientName.Text.Trim();
            int numIngredients;
            string unitName = txtMeasurement.Text.Trim();
            int calories;
            string foodGroup = txtFoodGroup.Text.Trim();
            

            if (string.IsNullOrEmpty(ingredientName))
            {
                MessageBox.Show("Please enter an ingredient name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (string.IsNullOrEmpty(unitName))
            {
                MessageBox.Show("Please enter a unit of measurement.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtCalories.Text.Trim(), out calories))
            {
                MessageBox.Show("Please enter a valid calorie value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (!int.TryParse(txtIngredientQuantity.Text.Trim(), out numIngredients))
            {
                MessageBox.Show("Please enter a valid value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Ingredient ingredient = new Ingredient { Name = ingredientName, Quantity = numIngredients, Measurement = unitName, Calories = calories, FoodGroup = foodGroup };
            selectedRecipe.Ingredients.Add(ingredient);
            lvIngredients.ItemsSource = selectedRecipe.Ingredients;
            lvIngredients.Items.Refresh();

            txtIngredientName.Text = string.Empty;
            txtIngredientQuantity.Text = string.Empty;
            txtMeasurement.Text = string.Empty;
            txtCalories.Text = string.Empty;
            txtFoodGroup.Text = string.Empty;

            CalculateTotalCalories();
        }

        private void lvRecipes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedRecipe = (Recipe)lvRecipes.SelectedItem;
            txtSelectedRecipe.Text = selectedRecipe != null ? selectedRecipe.Name : string.Empty;

            if (selectedRecipe != null)
            {
                lvIngredients.ItemsSource = selectedRecipe.Ingredients;
                lvIngredients.Items.Refresh();
                CalculateTotalCalories();
            }
            else
            {
                lvIngredients.ItemsSource = null;
                txtTotalCalories.Text = string.Empty;
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredientNameFilter = txtFilterIngredientName.Text.Trim();
            string foodGroupFilter = txtFilterFoodGroup.Text.Trim();
            int maxCaloriesFilter;
            int.TryParse(txtFilterMaxCalories.Text.Trim(), out maxCaloriesFilter);

            var filteredRecipes = recipes.Where(r =>
                r.Name.ToLower().Contains(ingredientNameFilter.ToLower()) &&
                r.Ingredients.Any(i => i.FoodGroup.ToLower().Contains(foodGroupFilter.ToLower())) &&
                (maxCaloriesFilter <= 0 || r.Ingredients.Sum(i => i.Calories) <= maxCaloriesFilter)).ToList();

            lvRecipes.ItemsSource = filteredRecipes;
            lvRecipes.Items.Refresh();
        }

        private void CalculateTotalCalories()
        {
            int totalCalories = selectedRecipe.Ingredients.Sum(i => i.Calories);
            txtTotalCalories.Text = totalCalories.ToString();
            

            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: Total calories exceed 300.", "Calorie Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            recipes.Clear();
            selectedRecipe = null;
            txtSelectedRecipe.Text = string.Empty;
            txtRecipeName.Text = string.Empty;
            txtIngredientName.Text = string.Empty;
            txtIngredientQuantity.Text = string.Empty;
            txtMeasurement.Text = string.Empty;
            txtCalories.Text = string.Empty;
            txtFoodGroup.Text = string.Empty;
            txtScale.Text = string.Empty;
            txtTotalCalories.Text = string.Empty;
            lvRecipes.ItemsSource = null;
            lvIngredients.ItemsSource = null;
        }
    }
}
