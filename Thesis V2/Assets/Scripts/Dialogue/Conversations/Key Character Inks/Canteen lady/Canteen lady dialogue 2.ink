// Canteen lady dialogue 2
-> cafeteriaStaff

=== cafeteriaStaff ===
Hey doc, how can we help regarding the suspected food contamination?
    + [Evidence links cafeteria]
        That's concerning. Any specific actions we should take?
            ++[Inspect kitchen]
            // went to the kitchen
                 Any initial thoughts on the contamination?
                    +++[Bin misplacement issue]
                    +++[Raw and cooked food]
                    +++[Dirty utensils]
                    - Got it. We'll address these concerns promptly.
                        -> DONE
    + [End Convo]
        -> DONE