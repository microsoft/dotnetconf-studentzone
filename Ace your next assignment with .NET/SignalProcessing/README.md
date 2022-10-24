# Create a moving average filter
## requirements

* the filter will be used with fixed sampling rate
* as new samples are pushed in teh filter moving averages are published
* make it composable by using observable pattern
* doesn't produce values untill the window is full
* the window moves by one sample (if the size is n then consecutive windows overlaps by n-1 samples)