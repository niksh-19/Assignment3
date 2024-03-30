Assignment 3: Implementing a Singly Linked List
This repository contains the code for a singly linked list (SLL) implementation in C#. The implementation includes a node class, a SLL class, and a test class for the SLL.

Node Class
The Node class represents a single node in the SLL. It contains a User object (the data) and a reference to the next node in the list.

SLL Class
The SLL class implements a singly linked list. It contains a head node and a size variable to keep track of the number of nodes in the list. The class provides methods for adding, removing, replacing, and retrieving nodes in the list. It also includes a Reverse method to reverse the order of the nodes in the list and a ToArray method to copy the values of the linked list nodes into an array.

Test Class
The LinkedListTest class contains unit tests for the SLL class. The tests cover adding nodes to the list, replacing nodes, deleting nodes, finding nodes, and reversing the order of the nodes.

Serialization
The SerializationHelper class provides methods for serializing and deserializing the SLL. This allows for the SLL to be saved to a file and later loaded back into memory.

Serialization Tests
The SerializationTests class contains tests for serializing and deserializing the SLL. The tests verify that the SLL is correctly serialized and deserialized, and that the data in the SLL is preserved.

How to Use
To use the SLL implementation in your own project, add the User, Node, SLL, and SerializationHelper classes to your project. You can then create an instance of the SLL class and use its methods to add, remove, and retrieve nodes in the list.

To serialize and deserialize the SLL, use the SerializeUsers and DeserializeUsers methods in the SerializationHelper class.
