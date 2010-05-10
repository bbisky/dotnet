
var kobj = new Object();
   kobj.RESET_BUTTON_TITLE_ = '清除所有测距标记';
   kobj.ENABLE_BUTTON_TITLE_ = '添加测距标记已启用，单击这里禁用';
   kobj.DISABLE_BUTTON_TITLE_ = '添加测距标记已禁用，单击这里启用';
    kobj.DELETE_BUTTON_TITLE_ = '删除';
        kobj.RESET_BUTTON_IMAGE_ = 'ruler_clear.png';
        kobj.ENABLE_BUTTON_IMAGE_ = 'ruler_enabled.png';
        kobj.DISABLE_BUTTON_IMAGE_ = 'ruler_disabled.png';
        kobj.BACKGROUND_IMAGE_ = 'ruler_background.png';
        kobj.KILOMETER_ = '公里';
        kobj.METER_ = '米';
        var northLatitude = '北纬';
        var southLatitude = '南纬';
        var westLongtitude = '西经';
        var eastLongtitude = '东经';
function GRulerControl() {
  var me = this;
  // 国际化的字符串
  me.RESET_BUTTON_TITLE_ = kobj.RESET_BUTTON_TITLE_;
  me.ENABLE_BUTTON_TITLE_ = kobj.ENABLE_BUTTON_TITLE_;
  me.DISABLE_BUTTON_TITLE_ = kobj.DISABLE_BUTTON_TITLE_;
  me.DELETE_BUTTON_TITLE_ = kobj.DELETE_BUTTON_TITLE_;
  me.RESET_BUTTON_IMAGE_ = kobj.RESET_BUTTON_IMAGE_;
  me.ENABLE_BUTTON_IMAGE_ = kobj.ENABLE_BUTTON_IMAGE_;
  me.DISABLE_BUTTON_IMAGE_ = kobj.DISABLE_BUTTON_IMAGE_;
  me.BACKGROUND_IMAGE_ =  kobj.BACKGROUND_IMAGE_;
  me.KILOMETER_ =kobj.KILOMETER_;
  me.KILOMETER_ = kobj.KILOMETER_;
  me.METER_=kobj.METER_;
}

GRulerControl.prototype = new GControl();

GRulerControl.prototype.initialize = function(map) {
  var me = this;
  var container = document.createElement('div');
  me.setButtonStyle_(container);

  // “启用/禁用”按钮
  var btnEnable = document.createElement('img');
  btnEnable.width = btnEnable.height = 19;
  GEvent.addDomListener(btnEnable, 'click',
    function() {
      me.setEnabled(!me.isEnabled());
    }
  );
  container.appendChild(btnEnable);

  // “重置”按钮
  var btnReset = document.createElement('img');
  btnReset.width = btnReset.height = 19;
  btnReset.src = me.RESET_BUTTON_IMAGE_;
  btnReset.title = me.RESET_BUTTON_TITLE_;
  GEvent.addDomListener(btnReset, 'click',
    function() {
      me.reset();
    }
  );
  container.appendChild(btnReset);

  // 距离标签
  var txtInfo = document.createElement('div');
  txtInfo.style.font = 'small Arial';
  txtInfo.style.fontWeight = 'bold';
  txtInfo.style.fontSize = '9pt';
  txtInfo.style.width = '82px';
  container.appendChild(txtInfo);

  // 初始化内部变量
  map.rulerControl_ = me;
  me.map_ = map;
  me.head_ = new Object();
  me.tail_ = new Object();
  me.head_.next_ = me.tail_;
  me.tail_.prev_ = me.head_;
  me.btnEnable_ = btnEnable;
  me.btnReset_ = btnReset;
  me.txtInfo_ = txtInfo;
  me.setEnabled(true);

  map.getContainer().appendChild(container);
  return container;
}


/**
 * 设置控件的格式
 */
GRulerControl.prototype.setButtonStyle_ = function(button) {
  button.style.backgroundColor="#fff";
  button.style.backgroundImage = 'url(' + this.BACKGROUND_IMAGE_ + ')';
  button.style.font = 'small Arial';
  button.style.border = '1px solid #888888';
  button.style.padding = '4px';
  button.style.textAlign = 'right';
  button.style.cursor = 'pointer';
}

/**
 * 用恰当的格式表示距离
 */
GRulerControl.prototype.formatDistance_ = function(len) {
  var me = this;

  len = Math.round(len);
  if (len <= 1000) {
    return len + ' ' + me.METER_;
  } else if (len <= 1000000) {
    return len / 1000 + ' ' + me.KILOMETER_;
  }
  return Math.round(len / 1000) + ' ' + me.KILOMETER_;
}

/**
 * 格式化角度为字符串
 */
GRulerControl.prototype.formatDegree_ = function(value) {
  value = Math.abs(value);
  var v1 = Math.floor(value);
  var v2 = Math.floor((value - v1) * 60);
  var v3 = Math.round((value - v1) * 3600 % 60);
  return v1 + '.' + v2 + v3;
}

/**
 * 格式化经纬度为字符串
 */
GRulerControl.prototype.formatLatLng_ = function(pt) {
  var me = this;

  var latName, lngName;
  var lat = pt.lat();
  var lng = pt.lng();
  latName = lat >= 0 ? northLatitude : southLatitude;
  lngName = lng >= 0 ? eastLongtitude : westLongtitude;

  return lngName + me.formatDegree_(lng) + ', '
    + latName + me.formatDegree_(lat);
}

/**
 * 返回控件的默认位置
 */
GRulerControl.prototype.getDefaultPosition = function() {
  return new GControlPosition(G_ANCHOR_TOP_RIGHT, new GSize(400, 8));
}

/**
 * 返回控件是否已启用
 */
GRulerControl.prototype.isEnabled = function() {
  return this.enabled_;
}

/**
 * 设置控件的“启用/禁用"状态
 */
GRulerControl.prototype.setEnabled = function(value) {
  var me = this;
  if (value == me.enabled_)
    return;
  me.enabled_ = value;

  if (me.enabled_) {
    me.mapClickHandle_ = GEvent.addListener(me.map_, 'click', me.onMapClick_);
    me.txtInfo_.style.display = 'block';
    me.btnReset_.style.display = 'inline';
    me.btnEnable_.src = me.ENABLE_BUTTON_IMAGE_;
    me.btnEnable_.title = me.ENABLE_BUTTON_TITLE_;
    me.updateDistance_();
  } else {
    GEvent.removeListener(me.mapClickHandle_);
    me.txtInfo_.style.display = 'none';
    me.btnReset_.style.display = 'none';
    me.btnEnable_.src = me.DISABLE_BUTTON_IMAGE_;
    me.btnEnable_.title = me.DISABLE_BUTTON_TITLE_;
  }
}

/**
 * 事件处理函数：当用户单击地图时，要在该位置添加一个标记
 */
GRulerControl.prototype.onMapClick_ = function(marker, latlng) {
  var me = this.rulerControl_;

  // 如果用户单击的是标记，不再这里处理
  if (marker)
    return;

  // 创建标记，并添加到链表中
  var newMarker = new GMarker(latlng, {draggable: true});

  var pos = me.tail_.prev_;
  newMarker.prev_ = pos;
  newMarker.next_ = pos.next_;
  pos.next_.prev_ = newMarker;
  pos.next_ = newMarker;

  // 为标记添加事件处理函数：拖拽标记时要更新连接线段和距离
  GEvent.addListener(newMarker, 'dragend',
    function() {
      me.map_.closeInfoWindow();
      me.updateSegments_(newMarker);
      me.updateDistance_();
    }
  );
  // 为标记添加事件处理函数：单击标记时要显示信息窗口
  GEvent.addListener(newMarker, 'click',
    function() {
      newMarker.openInfoWindow(me.createInfoWindow_(newMarker));
    }
  );

  // 将创建的标记添加到地图中
  me.map_.addOverlay(newMarker);

  if (newMarker.prev_ != me.head_) {
    // 如果这不是第一个标记，则创建连接到上一个标记的线段，并显示在地图中
    var segment = [newMarker.prev_.getLatLng(), latlng];
    newMarker.segPrev_ = new GPolyline(segment);
    newMarker.prev_.segNext_ = newMarker.segPrev_;
    me.map_.addOverlay(newMarker.segPrev_);

    // 更新距离显示
    me.updateDistance_();
  }
}

/**
 * 统计总距离，并显示在网页中
 */
GRulerControl.prototype.updateDistance_ = function() {
  var me = this;
  var len = me.getDistance();

  // 结果显示在网页中

  me.txtInfo_.innerHTML = me.formatDistance_(len);
}

/**
 * 遍历链表，统计总距离
 */
GRulerControl.prototype.getDistance = function() {
  var me = this;
  var len = 0;

  // 周游链表，累计相邻两个标记间的距离
  for (var m = me.head_; m != me.tail_; m = m.next_) {
    if (m.prev_ && m.prev_.getLatLng)
      len += m.prev_.getLatLng().distanceFrom(m.getLatLng());
  }
  return len;
}

/**
 * 清除所有标记，初始化链表
 */
GRulerControl.prototype.reset = function() {
  var me = this;

  for (var m = me.head_.next_; m != me.tail_; m = m.next_) {
    me.map_.removeOverlay(m);
    if (m.segNext_)
      me.map_.removeOverlay(m.segNext_);
  }
  me.head_ = new Object();
  me.tail_ = new Object();
  me.head_.next_ = me.tail_;
  me.tail_.prev_ = me.head_;

  me.updateDistance_();
}


/**
 * 事件处理函数：当用户拖拽标记、标记坐标改变时被调用，这里要更新与该标记连接的线段
 * @param {GMarker} marker 被拖拽的标记
 */
GRulerControl.prototype.updateSegments_ = function(marker) {
  var me = this;
  var segment;

  // 更新连接前驱的线段
  if (marker.segPrev_ && marker.prev_.getLatLng) {
    // 从地图上删除旧的线段
    me.map_.removeOverlay(marker.segPrev_);

    // 根据标记的当前坐标构造新的线段，并更新链表结点的相关字段
    segment = [marker.prev_.getLatLng(), marker.getLatLng()];
    marker.segPrev_ = new GPolyline(segment);
    marker.prev_.segNext_ = marker.segPrev_;

    // 将新线段添加到地图中
    me.map_.addOverlay(marker.segPrev_);
  }

  // 更新连接后继的线段，与上类似
  if (marker.segNext_ && marker.next_.getLatLng) {
    me.map_.removeOverlay(marker.segNext_);
    segment = [marker.getLatLng(), marker.next_.getLatLng()];
    marker.segNext_ = new GPolyline(segment);
    marker.next_.segPrev_ = marker.segNext_;
    me.map_.addOverlay(marker.segNext_);
  }
}


/**
 * 为信息窗口创建 DOM 对象，包括标记的坐标和“删除”按钮
 * @param {GMarker} marker 对应的标记
 */
GRulerControl.prototype.createInfoWindow_ = function(marker) {
  var me = this;

  // 为气泡提示窗口创建动态 DOM 对象，这里我们用 DIV 标签
  var div = document.createElement('div');
  div.style.fontSize = '10.5pt';
  div.style.width = '250px';
  div.appendChild(
    document.createTextNode(me.formatLatLng_(marker.getLatLng())));

  var hr = document.createElement('hr');
  hr.style.border = 'solid 1px #cccccc';
  div.appendChild(hr);

  // 创建“删除”按钮
  var lnk = document.createElement('div');
  lnk.innerHTML = me.DELETE_BUTTON_TITLE_;
  lnk.style.color = '#0000cc';
  lnk.style.cursor = 'pointer';
  lnk.style.textDecoration = 'underline';

  // 为“删除”按钮添加事件处理：调用 removePoint() 并重新计算距离
  lnk.onclick =
    function() {
      me.map_.closeInfoWindow();
      me.removePoint_(marker);
      me.updateDistance_();
    };
  div.appendChild(lnk);

  // 当用户关闭信息窗口时 Google 地图 API 会自动释放该对象
  return div;
}


/**
 * 事件处理函数：当用户选择删除标记时被调用，这里要删除与该标记连接的线段
 * @param {GMarker} marker 要删除的标记
 */
GRulerControl.prototype.removePoint_ = function(marker) {
  var me = this;

  // 先从地图上删除该标记
  me.map_.removeOverlay(marker);

  // 对于中间结点，还要把它的前驱和后继用线段连接起来
  if (marker.prev_.getLatLng && marker.next_.getLatLng) {
    var segment = [marker.prev_.getLatLng(), marker.next_.getLatLng()];
    var polyline = new GPolyline(segment);
    marker.prev_.segNext_ = polyline;
    marker.next_.segPrev_ = polyline;
    me.map_.addOverlay(polyline);
  }
  marker.prev_.next_ = marker.next_;
  marker.next_.prev_ = marker.prev_;

  if (marker.segPrev_)
    me.map_.removeOverlay(marker.segPrev_);
  if (marker.segNext_)
    me.map_.removeOverlay(marker.segNext_);
}

