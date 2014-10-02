Beer Flix
========

The social app for recommending a beer to go with your movie! Online and ready to roll!

Find it at https://beerflix.azurewebsites.net (soon to be updated to http://www.flix.beer, we bought the domain but it hasn't been updated on the DNS-server yet. Plus we are not really network guys so who knows, maybe we messed it up)

##What is BeerFlix?
BeerFlix is a project we started as a [Hackaton](http://en.wikipedia.org/wiki/Hackathon) during the annual KTH D-Dagen. We wanted to see how far we could get during one day of coding with constant (although welcome) interruptions from qurious students. We aim to develop the solution with a focus on high quality by honoring the aspects of TDD and clean code, the principles of [SOLID](http://en.wikipedia.org/wiki/SOLID_(object-oriented_design)) and mindset of a craftsman.

##So what does it do?
Well, let's say you want to watch a movie. Now naturaly you want a beer to go with that movie. Enter BeerFlix! By applying a very *scientifically proven associative prediction model* (**SPAPM**) to the movie-graph and then building a search criteria for beer attributes we can find the top 3 beers that according to the SPAPM matches the movie.

##Seriously?
Well, yeah. Uhhh. We do need some help with the **SPAPM** though. In order to fine tune it we intend to build a set of Beer-characteristics to Movie-attributes rules and mappings. Let me give an example:

> You are watching a very dark 2,5 hours drama by a French-Polish director. By translating the genre to a particular beer-style we can narrow it down to perhaps a Bitter (aka a brittish Pale Ale, butt Bitter sounds better fitting here right?). Then considering the length of the movie we don't want you too drunk at 1:38:25 in the movie so we keep the ABV fairly low. Then we can consider the origin of the director and narrow the origin of the brewery to a country.

Or 

> You are watching a bad american comedy with a low popularity ranking? Let's get you drunk real fast on some cheap american beer!

You get the point right? If you have input on how we can fine-tune the SPAPM with additional rules let us knok - add it as an Issue [here on Github](https://github.com/ffcg/beerflix/issues) directly and we'll add it. If it's a good rule that is.

##This sounds awsome, can I contribute?
Sure thing! Simplest way? Fork the repo and create a pull-request. You can also get in touch with us and let us know about your awsome idea.

fredrik.goransson at ffcg.se
arthur.onoszko at ffcg.se




