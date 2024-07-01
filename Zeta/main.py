import numpy as np
import math
import matplotlib.pyplot as plt

l = list(range (-1000,1000))
x = []
m_l = []
for t in l:
    try:
        m = math.exp(18 * pow(t/100,6))
    except OverflowError:
        m = np.nan
    print("For t = ",t/100)
    print("(e^18*t^6) = ",m)
    x.append(t/100)
    m_l.append(m)

plt.plot(x,m_l,'b--',linewidth=3)

plt.xlabel('t')
plt.ylabel('e^18*t^6')
plt.legend(['m_l'])

plt.show()
