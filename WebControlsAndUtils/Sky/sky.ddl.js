function SkyDropDownList(){    
     this.list = null;
     this.children = null;
     this.ipt_textbox = null;
     this.ipt_value = null;
     this.ipt_index = null
     this.selectedIndex = -1;
 };    
   
    
     SkyDropDownList.prototype.hidelist = function (){
     if(!this.list) return;
        this.list.style.display="none";
     };
      
      
        SkyDropDownList.prototype.hilightListItem = function(index){
           // var childNodes = document.getElementById("cb_list").children;
            var childLength = this.children.length;
            //dishilight
            if(this.selectedIndex > -1 && this.selectedIndex< childLength){
                this.children[this.selectedIndex].className = "";
            }            
            this.selectedIndex = index>=-1? index : -1;  
            if(this.selectedIndex > -1 && this.selectedIndex< childLength){
            var item = this.children[this.selectedIndex];             
             item.className="highlight";                
            }            
        };
                
        SkyDropDownList.prototype.showList = function(e){
            if(!this.list) return;
           var h = e.offsetHeight;
            var x = e.offsetLeft;
              var y = e.offsetTop;
              while(e = e.offsetParent){
                x += e.offsetLeft;
                y += e.offsetTop;
              }
            this.list.style.left = x +"px";
            this.list.style.top = y + h+ "px";
            this.list.style.position = "absolute";
            this.list.style.display = "block";
        };
       SkyDropDownList.prototype.selectedItem=function(index){
            var item = this.children[index];
            if(!item) return;
            this.ipt_textbox.value = item.innerHTML; 
            this.ipt_index.value= item.i; 
            this.ipt_value.value=item.value; 
            this.hidelist();
       };
        
        SkyDropDownList.prototype.keydown = function(e){     
        if(!e&&window.event)
            e=window.event;  
           
            if(e.keyCode==40){
                skyddl.hilightListItem(skyddl.selectedIndex+1);
                return false;
            }
            else if(e.keyCode==38){
                skyddl.hilightListItem(skyddl.selectedIndex-1);
                return false;
            }
            else if(e.keyCode==13){
                skyddl.selectedItem(skyddl.selectedIndex);
                return false;
            }
        };
var skyddl = new SkyDropDownList();