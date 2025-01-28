using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Katering.Services
{
    public class CartService
    {
        private readonly NavigationManager _navigationManager;

        // Dictionary to store meal IDs and their quantities
        private Dictionary<int, int> _cartItems = new Dictionary<int, int>();

        public CartService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public Dictionary<int, int> CartItems
        {
            get => _cartItems;
        }

        // Adds a meal ID to the cart and increments its quantity
        public void AddToCart(int mealId)
        {
            if (_cartItems.ContainsKey(mealId))
            {
                _cartItems[mealId]++;
            }
            else
            {
                _cartItems[mealId] = 1;
            }

            Console.WriteLine($"Meal {mealId} added to the cart. Quantity: {_cartItems[mealId]}");
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        // Decrements the quantity of a meal or removes it if the quantity becomes zero
        public void RemoveFromCart(int mealId)
        {
            if (_cartItems.ContainsKey(mealId))
            {
                _cartItems[mealId]--;

                if (_cartItems[mealId] <= 0)
                {
                    _cartItems.Remove(mealId);
                    Console.WriteLine($"Meal {mealId} removed from the cart.");
                }
                else
                {
                    Console.WriteLine($"Meal {mealId} quantity decreased to {_cartItems[mealId]}.");
                }
            }

            NavigateToCart();
        }

        // Removes a specific meal ID completely from the cart
        public void RemoveAllFromCart(int mealId)
        {
            if (_cartItems.ContainsKey(mealId))
            {
                _cartItems.Remove(mealId);
                Console.WriteLine($"All of meal {mealId} removed from the cart.");
            }

            NavigateToCart();
        }

        // Navigates to the Cart page with the cart items
        public void NavigateToCart()
        {
            var query = string.Join(",", _cartItems.Keys);
            _navigationManager.NavigateTo($"/cart?cartItems={query}");
            Console.WriteLine("Navigated to the cart page.");
        }
    }
}
