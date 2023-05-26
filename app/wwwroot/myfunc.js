mre=null

function test1(x){
 
}

function closeX(x){
    document.getElementById(x).className = "indexBar";
}


function openO(x){
    if (mre !=null) {
        close (mre)
    }
    const openO = document.getElementById(x);
    
    openO.className = "indexBarHighlight";
    
    mre=x
    
}


