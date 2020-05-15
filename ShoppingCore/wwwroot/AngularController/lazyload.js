var app = angular.module('myapp', []);


app.controller("lazycontroller", function ($scope, $http) {
    $scope.currentpage = 0;
    $scope.totalpage = 0;
    $scope.allCategory = 0;
    $scope.detailslist = [];
    $scope.path = "/ProductImage/";
    $scope.Cats = [{ id: '0', name: 'All'}, { id: '2', name: 'Living room furniture'},
        { id: '3', name: 'Dining room furniture'}, { id: '4', name: 'Bedroom furniture'}, { id: '5', name: 'Home Decor'}, { id: '6', name: 'Restaurant furniture'}];  

    $scope.catselected = $scope.Cats[0];

    $scope.subCats = [{ id: '0', name: 'All' }, { id: '1', name: 'Beds' }, { id: '2', name: 'Sofas' }, { id: '3', name: 'Chairs' }, { id: '4', name: 'Almirah' }, { id: '5', name: 'Bench' }, { id: '6', name: 'Dining Table' }];  


    function getdata(page, catid) {

        $scope.Isloading = true;
        $http.get("/Home/getLazyProducts?page=" + page + "&catid=" + catid).then(function (response) {
            angular.forEach(response.data.prodData, function (value) {
                $scope.detailslist.push(value);

            });
            $scope.totalpage = response.data.prodData.length;
            $scope.Isloading = false;
            if ($scope.totalpage >= 12) {
                $scope.IsMore = true;
            }
            else {
                console.log('false');
                $scope.IsMore = false;
            }
        }, function (error) {
            $scope.Isloading = false;
            alert('Failed');
        })
    }
    $scope.catSelect = function () {
        $scope.detailslist = [];    
        $scope.currentpage = 0;
        $scope.totalpage = 0;
        getdata(0, $scope.catselected.id);
    }
    

    getdata($scope.currentpage, $scope.allCategory);
    

    $scope.Nextpage = function () {
        if ($scope.currentpage < $scope.totalpage) {
            $scope.currentpage += 1;
            getdata($scope.currentpage, $scope.catselected.id);
        }
    };

    $scope.quickshop = function (data) {        
        getProducts(data);        
    }
});


var app = angular.module('cart', []);

app.controller("cartcontroller", function ($scope, $http) {    
    $scope.cartlist = [];
    $scope.totalPrice = 0;
    $scope.path = "/ProductImage/";

    function getdata() {

        $http.get("/shopping/CartData").then(function (response) {
            $scope.cartlist = [];
            $scope.totalPrice = 0;
            angular.forEach(response.data, function (value) {
                $scope.cartlist.push(value);
                $scope.totalPrice = $scope.totalPrice + (value.priceSale * value.totalProduct);
            });
            console.log($scope.totalPrice);
        }, function (error) {
            alert('Failed');
        })
    }

    
    getdata();


    $scope.AddtoCart = function (itemid) {
        $http.post("/shopping/AddProductToCart?itemId=" + itemid).then(function (response) {            
            getdata();
            swal({
                title: '',
                text: "Added to Cart",
                type: 'success'
            }, function () {
                getCart();
            });
        }, function (error) {
            alert('Failed');
        })
    };

    $scope.RemoveCart = function (itemid) {
        $http.post("/shopping/RemoveCart?itemId=" + itemid).then(function (response) {            
            getdata();
            swal({
                title: '',
                text: "Removed",
                type: 'success'
            }, function () {
                getCart();
            });
        }, function (error) {
            alert('Failed');
        })
    };

   
});




