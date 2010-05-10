 /*
*Author:karry
*Version:1.0
*Time:2008-12-01
*KMapSearch 类
*把GOOGLE MAP 和LocalSearch结合。只需要传入MAP\经纬度值，就可以把该经纬度附近的相关本地搜索内容取出来，在地图上标注出来，并可以在指定容器显示搜索结果
*/

(function() {
    var markers= new Array();
    var KMapSearch=window.KMapSearch= function(map_, opts_) {
        this.opts = {
            container:opts_.container || "divSearchResult",
            keyWord:opts_.keyWord || "餐厅",
            latlng: opts_.latlng || new GLatLng(31, 121),
            autoClear:opts_.autoClear || true,
            icon:opts_.icon || new GIcon(G_DEFAULT_ICON)
        };
        this.map = map_;
        this.gLocalSearch = new google.search.LocalSearch();
        this.gLocalSearch.setCenterPoint(this.opts.latlng);
        this.gLocalSearch.setResultSetSize(GSearch.LARGE_RESULTSET);
        this.gLocalSearch.setSearchCompleteCallback(this, function() {
            if (this.gLocalSearch.results) {
                var savedResults = document.getElementById(this.opts.container);
                if (this.opts.autoClear) {
                    savedResults.innerHTML = "";
                }
                for (var i = 0; i < this.gLocalSearch.results.length; i++) {
                    savedResults.appendChild(this.getResult(this.gLocalSearch.results[i]));
                }
            }
        });
    }
    KMapSearch.prototype.getResult = function(result) {
        var container = document.createElement("div");
        container.className = "list";
        var myRadom =(new Date()).getTime().toString()+Math.floor(Math.random()*10000);
        container.id=myRadom;
        container.innerHTML = result.title + "<br />地址：" + result.streetAddress;
        this.createMarker(new GLatLng(result.lat, result.lng), result.html,myRadom);
        return container;
    }
    KMapSearch.prototype.createMarker = function(latLng, content)
    {
        var marker = new GMarker(latLng, {icon:this.opts.icon,title:this.opts.title});
        GEvent.addListener(marker, "click", function() {
            marker.openInfoWindowHtml(content);
        });
        markers.push(marker);
        map.addOverlay(marker);
    }
    KMapSearch.prototype.clearAll = function() {
        for (var i = 0; i < markers.length; i++) {
            this.map.removeOverlay(markers[i]);
        }
        markers.length = 0;
    }
    KMapSearch.prototype.execute = function(keyword) {
        if (keyword) {
           this.gLocalSearch.execute(keyword);
        }
        
    }
})();