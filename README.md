# bliffoscope-analysis

> Bliffoscope Data Analysis

> It's April 1, 2143. Your job is to save the world.

> Well, a little world. Specifically the asteroid X8483-Z-32 that you and Alphonso Bliffageri are stuck on. You've been stranded there ever since the evil Rejectos hit your spaceship with a slime torpedo fired from one of their spaceships. Now you and Alphonso are trying to save your little world from a concerted Rejectos attack.

> The main problem you have is detecting the Rejectos spaceships and slime torpedos, because they're protected with cloaking devices. Alphonso has invented an imaging anti-neutrino system (which he has modestly named the 'Bliffoscope') that provides the only information you have about their location, but it's not very good information. First, the Bliffoscope only detects whether there are anti-neutrinos at any particular point on an image, not what their intensity is. In other words, the data it provides is the equivalent of a black-and-white image. Second, the data is very noisy even if there are no targets in a particular area, some pixels will be 'on', and if there is a target, some of its pixels will be 'off'. For example, here's a 20 x 20 sample of raw data from the Bliffoscope (where each '+' is a pixel that is on):

   +       + ++ + + 
+     +   +++ ++  ++
     ++    + ++  ++ 
+ + ++  + + + + ++  
           ++ ++ +++
+       +   + +   + 
   +       +        
 +       ++    +    
 +  +          ++  +
     + +       +    
+       +    +++    
   +       +  +     
    +               
  +    +  +   +    +
 +       ++      +  
         +  +  +    
     +     +     +  
     +      +       
 +      +          +
     ++  +  +    +  
Below is a sample image of a slime torpedo:

    +    
    +    
   +++   
 +++++++ 
 ++   ++ 
++  +  ++
++ +++ ++
++  +  ++
 ++   ++ 
 +++++++ 
   +++   
On the Bliffoscope data, we've highlighted the pixels that should be 'on' for a slime torpedo. You can see that more of the highlighted pixels are 'on' in the highlighted area than in other areas of the image. You must use this difference to locate the targets in the Bliffoscope data. Along with this document you've received three files, all text files using '+' symbols to represent 'on' pixels and spaces to represent 'off' pixels:

TestData.txt: a 100 x 100 swath of raw Bliffoscope data containing between four and ten targets.

SlimeTorpedo.txt: a perfect image of a slime torpedo.

Starship.txt: a perfect image of a Rejectos starship.

Your task is to do the following:

Design and write a Java package that can analyze arbitrary-sized Bliffoscope images, returning a list of targets found. Each target found should include the target type found (starship or slime torpedo), the coordinates of the target on the Bliffoscope data, and some indication of your confidence in the target detection.

Design and write test code that submits the test data to your package and prints the results returned by your package.

After defeating the Rejectos using your target data, submit your program and the test results back to me by. If your code fails todetect the targets, submit it anyway we'd like to see how you attempted it.