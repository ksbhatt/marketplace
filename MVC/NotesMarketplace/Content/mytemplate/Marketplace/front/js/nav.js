document.getElementById('icon8').onclick = function() {    
        document.getElementById('icon9').style.display="block";
        document.getElementById('icon8').style.display="none";    
        }
        
        
        document.getElementById('icon9').onclick = function() {    
        document.getElementById('icon8').style.display="block";
        document.getElementById('icon9').style.display="none";    
        }
        
        var myNav = document.getElementById("wrapper");
        var myNavv = document.getElementById("navigation");
        

        window.onscroll = function() {
          "use strict";
          if (document.body.scrollTop >= 280 || document.documentElement.scrollTop >= 280) {
            myNav.classList.add("scroll");
            myNavv.classList.add("sc");  
            document.getElementById('imgid').src="../admin/images/logo.png";  
          } else {
            myNav.classList.remove("scroll");
            myNavv.classList.remove("sc");  
            document.getElementById('imgid').src="../front/images/top-logo.png";  
          }
        };
        
        
        function myFunction() {
        var x = document.getElementById("navigation");
        if (x.className === "navigation-wrapper") {
            x.className += " responsive";
        } else {
            x.className = "navigation-wrapper";
        }
        }

function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}

