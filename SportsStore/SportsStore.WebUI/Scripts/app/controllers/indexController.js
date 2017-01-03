app.controller("indexController", function ($scope) {
    //$state.go('category', { categ: 'all', page: 1 });
});

app.controller('categController', function ($scope, storeService) {
    $scope.categories = [];
    $scope.selected = "Knives";
    $scope.getlistCategories = function () {
        storeService.getlistCategories().then(function (response) {
            $scope.categories = response.data;
        });
    }
    $scope.getlistCategories();

    $scope.discounts = [];
    $scope.selectedDisc = 0;

    $scope.getlistDiscounts = function () {
       storeService.getlistDiscounts().then(function (response) {
            $scope.discounts = response.data;
        });
    }
    $scope.getlistDiscounts();
});

app.controller('wishListController', function ($scope, storeService) {
    $scope.wishes = [];
    $scope.name = "505";

    $scope.getWishes = function (userid) {
       storeService.getWishList(userid)
        .then(function (response) {
            $scope.wishes = response.data;
            console.log("success for get wishes");
        })
        .catch(function (response) {
            console.error('Gists error', response.status, response.config, response.statusText, response.data);
        })
        .finally(function () {
            console.log("finally finished gists");
        });
    }
    
    $scope.addWish = function (productid, userid) {
           storeService.postWish(userid, productid).then(function (response) {            
               console.log("wish is added");
           });
    }
});

app.controller('productController', function ($scope, $stateParams, storeService) {   
  

    $scope.categ = $stateParams.categ;
    $scope.pages = [];
    $scope.products = [];
   
    $scope.totalPages;
    $scope.currentPage;
    $scope.getCategory = function (category, page) {
      
            storeService.getCategory(category, page).then(function (response) {
                $scope.products = response.data;
                $scope.totalPages = response.data.PagingInfo.TotalPages;
                $scope.currentPage = response.data.PagingInfo.CurrentPage;

               
                for (var i = 1; i <= $scope.totalPages; i++)
                    $scope.pages.push(i);
                //$scope.category = response.data.CurrentCategory;

            });
    }

    $scope.getCategory($stateParams.categ, $stateParams.page);
});

app.controller('searchController', function ($scope, $stateParams, storeService) {
    $scope.categ = $stateParams.categ;
    $scope.pages = [];
    $scope.products = [];

    $scope.totalPages;
    $scope.currentPage;
    $scope.searchProducts = function (name, category, page) {
        console.log("search " + name);
        storeService.searchProducts(name, category, page).then(function (response) {
            $scope.products = response.data;
            $scope.totalPages = response.data.PagingInfo.TotalPages;
            $scope.currentPage = response.data.PagingInfo.CurrentPage;
            

            for (var i = 1; i <= $scope.totalPages; i++)
                $scope.pages.push(i);
            //$scope.category = response.data.CurrentCategory;          
        });
    }

    $scope.searchProducts($stateParams.name, 'all', $stateParams.page);
});

app.controller('quickSearchController', function ($scope, $stateParams, storeService, $state) {
    //- pre-search
    $scope.keyword = "";
    $scope.count = "";

    $scope.getSearchResultCount = function () {
        $scope.count = "";
        storeService.getProdSearchQuant($scope.keyword).then(function (response) {
            $scope.count = response.data;
            $scope.count = "Found " + $scope.count + " item(s)";
            // console.log(response.data);       
        });
    }
    $scope.getSearchResult = function () {
        $state.go('search', { name: $scope.keyword, page: 1 });
    }
});
