// Canteen lady dialogue 1

-> cafeteriaStaff

===cafeteriaStaff===
Good morning! Welcome to the cafeteria.
    +[Introduce as a public health and food safety doctor]
        Nice to meet you doc! need anything?
            ++[Discuss the expanding disease]
            ++[Request to inspect the kitchen for safety]
            - Hold on! Are you saying my kitchen is involved? Unbelievable.
                +++[Apologize and explain the purpose of the inspection]
                    Fine! If you can prove our kitchen is unsafe, we'll allow an inspection.
                    -> DONE
                        
    +[End convo]
        -> DONE    


