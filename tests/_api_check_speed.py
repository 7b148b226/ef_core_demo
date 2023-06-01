from requests import request
from time import time
from random import choice,randint
from multiprocessing import Pool

url='http://localhost:5001/api/tests/single-insert'

def multithreading_coefficient(x):
	return 1+x/60*.15

def delegate(x):
	st=time()
	request('post',f'{url}')
	return round(time()-st,6)

if __name__=='__main__':
	processes,requests=1,1000
	coefficient=multithreading_coefficient(processes)
	st=time()
	results=Pool(processes).map(delegate,range(requests))
	print(f'max={max(results)}')
	print(f'min={min(results)}')
	print(f'avg={round(coefficient*sum(results)/len(results)/processes,6)}')
	print(f'\ntotal={round(time()-st,6)}')
