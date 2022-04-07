 export default {
    base_api: 'https://localhost:44324',
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

    artEvents : function (id) {
        return this.base_api+'/ArtEvents'+this.setid(id);        
    },
    parties: function (id) {
        return this.base_api+'/Parties'+this.setid(id);
    },
    classicmusic: function (id) {
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
    }
}