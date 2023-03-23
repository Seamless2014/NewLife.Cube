function svg(){
	this.twConstants = {
		DIALECT_SVG:"svg",
		DIALECT_VML:"vml",
		NS_SVG:"http://www.w3.org/2000/svg",
		NS_XLINK:"http://www.w3.org/1999/xlink"
	}
	
	this.emptySVGSrc = "./twaver/emptySVG.svg";
	
}

svg.prototype = {
	getSVGDocument : function(svg){
	    var result=null;
	    if(isIEBrowser()){
	        if(svg.tagName.toLowerCase()=="embed"){
	            try{
	                result=svg.getSVGDocument();
	            }catch(e){
	                alert(e+" may be svg embed not init");
	            }
	        }
	    }else{
	        result=svg.ownerDocument;
	    }
	    return result;
	},
	
	getSVGRoot : function(svg,doc){
	    if(svg.tagName.toLowerCase() == "embed"){
	        if(doc){
	            return doc.documentElement;
	        }else{
	            return this.getSVGDocument(svg).documentElement;
	        }
	    }else if(svg.tagName.toLowerCase() == "svg"){
	        return svg;
	    }return null;
	},
	
	createSVG : function(id,parent){
	    var svg;
	    if(isIEBrowser()){
	        svg=document.createElement("embed");
	        svg.setAttribute("id",id);
	        svg.setAttribute("type","image/svg+xml");
	        svg.setAttribute("src",this.emptySVGSrc);
	    }else {
	        svg=document.createElementNS(this.twConstants.NS_SVG,"svg");
	    }
	    svg.setAttribute("width","100%");
	    svg.setAttribute("height","100%");
	    parent.appendChild(svg);
	    return svg;
	},
	
	getSvg : function(id, parent, callback){
		var svg = this.createSVG(id,parent);
		var svgdoc = this.getSVGDocument(svg);
	    var svgRoot = this.getSVGRoot(svg);
	    callback(svgdoc, svgRoot);
	}
		
}

/**
//��SVG�ļ�·��

//��Html�д���һ��SVG�ڵ㣬ָ��id�����׽ڵ㣬����IE�������������������<SVG />

//�õ�SVG�����

//��չsetTimeout������ʵ����ʱִ��
function doLater(callback,timeout,param)
{
    var args = Array.prototype.slice.call(arguments,2);
    var _cb = function()
    {
        callback.apply(null,args);
    }
    setTimeout(_cb,timeout);
}

//______���Դ���_______
var svg;
var addRect=function(svg){
    var svgdoc=getSVGDocument(svg);
    var svgRoot=getSVGRoot(svg);
    var rect=svgdoc.createElementNS(this.twConstants.NS_SVG,"path");

	rect.setAttribute("d",d);
	rect.setAttribute("fill-opacity","0.5");
	rect.setAttribute("stroke-opacity","0.5");
	rect.setAttribute("stroke-dasharray","none");
	rect.setAttribute("stroke-linejoin","round");
	rect.setAttribute("stroke-linecap","0.5");
	rect.setAttribute("stroke-width","2");
	rect.setAttribute("fill","yellow");
	rect.setAttribute("stroke","blue");

    // rect.setAttribute("id","rect2");
    // rect.setAttribute("x",10);
    // rect.setAttribute("y",10);
    // rect.setAttribute("width",200);
    // rect.setAttribute("height",200);
    // rect.setAttribute("fill","red");
    svgRoot.appendChild(rect);

}
function call(){
    var body=document.getElementsByTagName("body")[0];
    svg=createSVG("svgid",body);
    /**
    //�������SVG������������SVGElement������IE��Ҫ��ʱִ��
    if(isIE){
        doLater(function(svg){
            addRect(svg);
        },100,svg);
    }else{
        addRect(svg);
    }
    
}
function showmsg()
{
    //���ﲻ��Ҫ��ʱִ�У���Ϊ�������ڰ�ť����¼��У�SVG�Ѿ���ʼ��
    addRect(svg);
}**/