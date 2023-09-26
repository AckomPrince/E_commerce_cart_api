# Unified E-commerce Cart API
This API allows users to manage their shopping carts efficiently.

# Features
## 1. Add Items to Cart
- Endpoint: `/api/CartItems/Add`
- Request Body:
![add](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/962502cd-862e-4499-adba-d3807c802e41)


## 2. List Cart Items
- Endpoint: `/api/CartItems/List`
- Request Body:
- ![List](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/355f995f-1e03-40ee-b685-4c84b172f931)


## 3. Remove Item from Cart
- Endpoint: `/api/CartItems/{itemId}`
- Request Body:
![Delete](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/ad45f89e-83d0-4a85-992a-610d626c7e34)
 ![deleted_list](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/6701a92e-9e9c-4b66-bded-31e3b7647127)

## 4. Adding similar items (same item ID) increases the quantity
- Endpoint: `/api/CartItems/Add`
- Request Body:
- ![multiple_item](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/d83e39f9-2099-4080-a895-980aefccd46f)



## 5. Get Single Item
- Endpoint: `/api/CartItems/{itemId}`
- Request Body:
![singleItem](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/5d5e49c0-a083-45e2-a295-24f8dc9ec288)

## 6. Filter
### Query Parameters:
  - phoneNumber : Filter by user's phone number.
  - time : Filter by a specific time range.
  - quantity: Filter by item quantity.
  - item : Filter by item name.
  
### By  phoneNumber
![phoneNumber](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/aa8b4531-3684-4a90-b02b-a61824d97272)


### By  time
![time](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/de787ed0-01e0-4e80-a3ad-22a4b902790e)



### By   quantity  

![quantity](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/71ca0dbb-7464-4530-8053-2100e1803e1c)


### By  Item Name


![item](https://github.com/AckomPrince/E_commerce_cart_api/assets/53309877/7d5217e8-74dd-4c58-a339-ed34d86aa70d)

