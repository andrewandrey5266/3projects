app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        
        .state('user', {
            url: '/user/:id',
            template: '<h1>Hello from user #{{id}}</h1>',
            controller: 'productController'
        })
        //-- mvc
       .state('home', {
            url: '/home',
            template: '<h1>Welcome to cold steel store</h1>',
            controller: 'indexController'
        
        })
      
        .state('login', {
            url: '/login',
            templateUrl: 'Account/Login'      
        })
        .state('contacts', {
            url: '/contacts',
            template:  '937-99-92 our hot line'
        })
        .state('category', {
            url: '/category/:categ/:page',
            templateUrl : 'MyHtml/ProductList.html',
            controller: 'productController'            
        })

        .state('search', {
            url: '/search-item/:name/:page',
            templateUrl: 'MyHtml/ProductList.html',
            controller: 'searchController'
        })

        .state('detailed', {
            url: '/detailed/:productId',
             templateUrl: 'MyHtml/ProductPage.html',
             controller: 'productPageController'
        })

        //-- doesn't work
        .state('editProduct', {
            url: '/edit',
            templateUrl: 'Admin/Create',
            controller: 'categController'
        })
   
});