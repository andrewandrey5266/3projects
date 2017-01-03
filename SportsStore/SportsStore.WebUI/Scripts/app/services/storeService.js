
app.service('storeService', function ($http) {
  
    //------------------------------------------------- search : products
    this.getProdSearchQuant = function (keyword) {
        return $http.get('api/ProductApi/GetProductQuantity', { params: { keyword: keyword } });
    }
    this.searchProducts = function (name, category, page) {
        return $http.get('api/ProductApi/GetProducts', { params: { name: name, category: category, page: page } });
    }
    //-/

    //------------------------------------------------- product : list, page

    this.getCategory = function (category, page) { 
        return $http.get('/api/ProductApi/GetProducts', { params: {category :category , page : page} });
    }
    this.getProduct = function(productId){
        return $http.get('/api/ProductApi/GetProductDetailed', { params: { productId: productId } });
    }
    //-/



    //------------------------------------------------- review: getall , postone
    this.getReviews = function(productId){
        return $http.get('/api/ReviewApi/GetReviews', { params: { productId: productId } });
    }
    //-/


    //------------------------------------------------- drop down lists : category, discount

    this.getlistCategories = function () {
        return $http.get('/api/CategoryApi/GetCategories');
    }
    this.getlistDiscounts = function () {
        return $http.get('/api/DiscountApi/GetDiscounts');
    }
    //-/


    //------------------------------------------------- wishlist
    this.getWishList = function (userid) {
        return $http.get('/api/WishListApi/GetWishes', { params: { userId: userid } });
    }
    this.postWish = function (userid, productid) {        
        return $http.get('/api/WishListApi/PostWish', { params: { productid: productid, userId: userid  } });
    }
    //-/


});