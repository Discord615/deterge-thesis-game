// Canteen lady dialogue 2
-> cafeteriaStaff

=== cafeteriaStaff ===
Hey doc, how can we help regarding the suspected food contamination?
    + [I found evidence linking cafeteria meals]
        That's concerning. Any specific actions we should take?
            ++[I'd like to inspect the kitchen]
            // went to the kitchen
                 Any initial thoughts on the contamination?
                    +++[Improper bin placement near food prep]
                    +++[Mixing raw food with cooked food]
                    +++[Dirty utensils]
                    - Got it. We'll address these concerns promptly.
                        -> DONE
    + [End Convo]
        -> DONE