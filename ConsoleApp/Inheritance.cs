using OOP;

namespace Object.Oriented;
class African : Person
{

}

class Asian : Person
{

}

class Nepalese : Asian, ICulture
{
    public void SpeakLang()
    {
        
    }
}

// inherit from base class
// implement interface

// Multilevel
// Single
// Multiple

interface ICulture
{
    void SpeakLang();
}
