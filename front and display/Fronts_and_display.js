class Node {
    constructor(info){
        this.value=info;
        this.next=null;
    }
}

class SLL {
    constructor() {
        this.head = null;
    }

  addToFront(value){
  var new_node = new Node(value)
  if(this.head == null){
    this.head=new_node;
    // console.log(new_node.value)

    return this
    }
  new_node.next= this.head
  this.head=new_node
  // console.log(new_node.value)
    
  }
  displayList(){
    if (this.head == null) {
      console.log("SLL is empty")
      return this;
    }
   
    var runner = this.head;
    while (runner !== null ) {
      console.log( runner.value );
      runner = runner.next;
    }
    
  } 

  pop_front() {
  if(this.head != null) {
    
    //1. if head is not null, create a
    //   TEMP node pointing to head
    var TEMP = this.head;

    //2. move head to next of head
    this.head = this.head.next; 

    //3. delete TEMP node
    // free(TEMP); 
  }
}

  
 
    // constructor, other methods, removed for brevity
 front() {
   if(this.head != null) {
    
    //1. if head is not null, create a
    //   TEMP node pointing to head
    var TEMP = this.head.value;

    //2. move head to next of head
    // TEMP = this.head.next; 

    //3. delete TEMP node
    // free(TEMP); 
     return TEMP;
  }else{
      console.log("SLL is empty")
      return this;
  }
   
   
    	
    }
 


  
}

var my_newSLL = new SLL();

my_newSLL.addToFront("Enes").addToFront("Vrana");
my_newSLL.displayList();

my_newSLL.pop_front();
my_newSLL.displayList();


console.log(my_newSLL.front())
