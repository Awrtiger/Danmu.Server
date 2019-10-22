# 直播

## 解释几个基本问题

先来理解几个基问题

### 主要的直播协议有哪些？

- RMTP，基于TCP的传输协议，直播延时较小，一般可以控制在3s以内，网页播放需要Flash；
- RTSP，具有很复杂的一种传输协议，并不常见，我做了这么长时间，也只在编码器上见过，直播延时非常小；
- HLS，苹果的，格式为m3u8格式，H5支持比较好，浏览器原生支持，但是直播延时较大（一般在15s以上）；
- HTTP-FLV，FLV流，H5支持比较好，可以使用flv.js播放，直播延时较小，与RTMP相当。

### 直播的主要流程是什么？

大致上就是你先把直播流推到服务器上，然后服务器接收直播流，然后重新编码或者直接转发出来，然后客户端再发出请求，获得直播流，显示出来。

1. 推流，使用导播软件（比如OBS或者ffmpeg）多直播源编码，使用合适的协议（通常是rtmp）推流到服务器；
2. 转码，服务器有相应的软件处理对应的协议（比如使用nginx的nginx-rtmp-module模块），转码最简单的是使用ffmpeg；
3. 拉流，使用客户端（比如浏览器），请求经服务器转发后的流，然后播放出来。

### 直播服务器除了直播还有哪些用处？

除了直播之外，还可以用于转码，流转发等。

比如你想要同时在多个平台直播怎么弄？你想要同时在国内和国外的平台上直播，要怎么做？答案是自己搭建一个直播服务器去转发直播流。

### 直播对服务器压力大不大？

大，非常大，我一台服务器（i7-4770HQ + 16G内存）只能给一个直播流转码用，而且CPU占用特别的高。除了转码压力之外，直播对网络压力也特别的大，如果不是为了测试，或者是在局域网直播，强烈建议直接购买直播产品（有直接搭建好的直播平台，价格非常高，但是功能非常完善，也可以去购买直播服务，然后自己搭建直播平台，价格相对来说会便宜好多），本文仅针对使用DPlayer播放直播流进行讨论，对直播服务不做过多介绍。


## 方案选择

主要的可选方案有两个：

- RTMP推流 + HLS拉流
- RTMP推流 + HTTP-FLV拉流

本文主要针对第二种方案详细介绍，第一种仅做粗略介绍