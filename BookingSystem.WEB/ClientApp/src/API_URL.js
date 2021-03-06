 export default {
    base_api: 'https://localhost:5001',     
    account : '/account',
    setid: (id)=>{
        if (!id) {
            id='';
        }
        else{
            id='/'+id;
        }
        return id;
    },
    basePath: function myfunction() {
        return this.base_api;
    },
    getArtEvents : function (id) {
        return this.base_api+'/ArtEvents'+this.setid(id);        
    },
    getArtEventWithFilterQuery: function (filteringData){
        // console.log(filteringData);
        // const nameFilter= filteringData.nameForFilter??'';
        // const typeForFilter = filteringData.typeForFilter??'';  
        // const sortBy = filteringData.sortBy??'id';

        // console.log(nameFilter);
        // console.log(typeForFilter);
        // console.log(sortBy);
       
            return this.base_api+'/ArtEvents/?NameForFilter=' + filteringData.nameForFilter +'&TypeForFilter=' + filteringData.typeForFilter +'&sortBy=' +filteringData.sortBy    
    },
    parties: function (id) {
        return this.base_api+'/Parties'+this.setid(id);
    },
    classicmusics: function (id) {
        return this.base_api+'/classicMusic'+this.setid(id);
    },
    openairs : function (id) {
        return this.base_api+'/openAirs'+this.setid(id);
    },
    getExternalProviderName: function(){
        return this.base_api+'/account/getexternalproviders'
    },
    logout: function(){
        return this.base_api +'/account/logout'
    },
    getLoginInfo: function(){
        return this.base_api +'/account/loginfo'
    },
    checkCartItem: function(cart){
        return  this.base_api +'/checkcartitem'+'?id='+cart.id+'&quantity='+cart.quantity
    },    
    getFullCheckedListForCart: function (enumerableINT) {
        let queryString = enumerableINT.reduce((current,item,index)=>{            
            if (index==0) {
                return current+item;              
            } else{
                return current+ "&id="+ item;
            }    
        },"?id=");
        return this.base_api +"/checkcartitem/GetCurrentListOfArtEvent"+queryString
    },
    createOrder: function (){
        return this.base_api+ "/api/Order/Create"
    },
    getOrders : function (){
        return this.base_api+ "/api/Order/GetAsync"
    }  ,
    login : function () {
        return this.base_api+ "/account/Login"
    }, 
    register : function(){
        return this.base_api + "/account/Register"
    }
}