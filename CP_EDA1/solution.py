
def kthSmallest(mat, n, k):
    import heapq
    H = []
    
    pos = [0] * n
    
    for i in range(n):
        # print((-mat[i][0], i))
        heapq.heappush(H, (mat[i][0], i))
    
    for i in range(k-1):
        x = heapq.heappop(H)
        # print(x)
        ind = x[1]
        pos[ind]+=1
        if pos[ind]<n:
            heapq.heappush(H, (mat[ind][pos[ind]], ind))
        
    return (heapq.heappop(H)[0])

###################################################################################################################################

# Heap #
#Dise˜ne un algoritmo que, dados un heap H de m´ınimos y un n´umero x, devuelva todos los elementos en H que
#son menores que x. Su algoritmo debe ser O(k), donde k es la cardinalidad de la respuesta.
def CP_1_Solve_Heap(heap_of_min,x):
    import heapq
    queue = []
    solution = []
    queue.append(heapq.heappop(heap_of_min))

    while queue != []:
        subject = queue.pop(0)
        if subject.Left < x:
            queue.append(subject.Left)
        if subject.Right < x:
            queue.append(subject.Right)
        solution.append(subject)
    return solution

#####################################################################################################################################

#Dise˜ne un algoritmo que, dados un heap H de m´aximos, un n´umero x y un n´umero 0 ≤ k < |H|, identifique
#si el k-´esimo mayor elemento de H es mayor o igual a x. Su algoritmo debe tener una complejidad temporal O(k).

def CP_2_Solve_Heap(heap_of_max,x,k,):
    import heapq
    queue = []
    queue.append(heapq.heappop(heap_of_max))
    nodes_visited = 0
    while queue != [] or nodes_visited < k:
        node =queue.pop(0)
        if node.Left is not None and node.Value >= x:
            queue.append(node.Left)
            nodes_visited += 1
        if node.Right is not None and node.Value >= x:
            queue.append(node.Right)
            nodes_visited += 1
    return nodes_visited >= k

#####################################################################################################################################

#Dise˜ne un algoritmo que, dado un heap de m´aximos, obtenga el k-´esimo mayor elemento en ese heap. Su
#algoritmo debe tener una complejidad temporal O(k log k).

def CP_3_Solve_Heap(heap_of_max,k):
    import heapq
    nodes_to_visit = []
    nodes_to_visit.append(heapq.nlargest)
    nodes_visited = 0
    sol_list_sorted = []

    while nodes_to_visit != [] or nodes_visited != k:

        nodes_visited += 1
        actual_node = nodes_to_visit.pop

        if nodes_to_visit !=[]:
            nodes_to_visit.remove(actual_node) 

        sol_list_sorted.append(actual_node)

        if actual_node.Left is not None and actual_node.Right is not None:

            if actual_node.Left.Value > actual_node.Right.Value:
                nodes_to_visit.append(actual_node.Right)

                if actual_node.Left.Value < max(nodes_to_visit):
                    nodes_to_visit.append(actual_node.Left)
                    nodes_to_visit.append(max(nodes_to_visit))
                else:
                    nodes_to_visit.append(actual_node.Left)

            else:
                nodes_to_visit.append(actual_node.Left)
                
                if actual_node.Right.Value < max(nodes_to_visit):
                    nodes_to_visit.append(actual_node.Right)
                    nodes_to_visit.append(max(nodes_to_visit))
                else:
                    nodes_to_visit.append(actual_node.Right)


        elif actual_node.Left is not None:

            if actual_node.Left.Value < max(nodes_to_visit):
                    nodes_to_visit.append(actual_node.Left)
                    nodes_to_visit.append(max(nodes_to_visit))
            else:
                nodes_to_visit.append(actual_node.Left)


        elif actual_node.Right is not None:

            if actual_node.Right.Value < max(nodes_to_visit):
                    nodes_to_visit.append(actual_node.Right)
                    nodes_to_visit.append(max(nodes_to_visit))
            else:
                nodes_to_visit.append(actual_node.Right)

    return sol_list_sorted

############################################################################################################################################

############################################################################################################################################

#Disjoint Set

# Usted posee un mapa de n × m unidades cuadradas que representa verazmente un conjunto de islas en un
# archipi´elago. Cada casilla del mapa marca una zona con agua o tierra exclusivamente. En el mapa una isla es
# una regi´on maximal donde solo hay tierra y es posible moverse de cualquier casilla hacia otra con una secuencia
# de movimientos norte, sur, este u oeste sin tocar una casilla con agua. Dise˜ne un algoritmo que dado el mapa
# permita conocer:
# El ´area de la isla de mayor ´area.
# El ´area de la isla de menor ´area.
# La cantidad de islas que poseen la menor ´area.
# La complejidad de su algoritmo debe ser O(nm log(nm))


# def CP_3_Solve_DS(map):

#     all_objects_directions = [(i, j) for i in range(len(map)) for j in range(len(map[0])) if map[i][j]]

#     father_directions = [i for i in range(len(all_objects_directions))]

#     node_set_counter = [1 for i in range(len(all_objects_directions))]

#     for row in range(len(map)):
#         for col in range(len(map[0])):


# def SetOf(tupla,father_directions,all_objects_directions):
#     if father_directions[all_objects_directions.index(tupla)] == all_objects_directions.index(tupla):
#         return (tupla)
#     return SetOf(all_objects_directions[father_directions[all_objects_directions.index(tupla)]],father_directions,all_objects_directions)

# def Merge( tupla1,tupla2,father_directions,all_objects_directions,node_counter ):
#     father1 =SetOf(tupla1,father_directions,all_objects_directions)
#     father2 =SetOf(tupla2,father_directions,all_objects_directions)

#     if node_counter[father1] < node_counter[father2]:
#         father1 , father2 = father2, father1

#     node_counter[father1] += node_counter[father2]
#     father_directions[father2] = father_directions[father1]


###################################################################################################################################

###################################################################################################################################

# Trie

# Sea S = {s1, s2, . . . , sn} un conjunto de cadenas sobre el alfabeto ingl´es, donde |S| = n y sumatoria de |si| = m tq si∈S .
# Dise˜ne una estructura de datos con las siguientes operaciones:
# Build(S): Crea la estructura a partir de S. O(m)
# Search(t): Debe devolver si existe un si ∈ S tal que t sea sufijo de si(t]si). O(|t|

def CP_1_Solve_Build(S: list[str]):
    root_trie = '^'
    for word in S:
        word = word[::-1]
        Cp_1_Solve_Insert(root_trie,word)
    return root_trie

def CP_1_Solve_Search(actual_node,t: str):
    for children in actual_node.List_of_Children:
        if children.Value == t[0]:
            CP_1_Solve_Search(children,t[1:])
    return t.count == 0

def Cp_1_Solve_Insert(actual_node,word):
    if word == '':
        return
    for children in actual_node.List_of_Children:
        if children.Value == word[0]:
            Cp_1_Solve_Insert(children,word[1:])

    actual_node.List_of_Children.append(Trie_Node(word[0]))
    return

def Trie_Node(value):
    return 

###################################################################################################################################

# Dise˜ne una estructura de datos T que soporte las siguientes operaciones:
# Insert(s): Inserta una cadena s en T. O(|s|)
# Prefix(s): Devuelve la cantidad de cadenas presentes en T que contienen a s como prefijo propio. O(|s|).
# Nota: Una cadena s se dice prefijo propio de x si s es prefijo de x y s != x

def CP_2_Solve_Insert_with_COunt_Final(actual_node,s):
    for children in actual_node.List_of_Children:
        if children.Value == s[0]:
            children.Count += 1
            CP_2_Solve_Insert_with_COunt_Final(children,s[1:])
    actual_node.Final +=1
    actual_node.List_of_Children.append(Trie_Node(s[0]))
    return

def CP_2_Solve_Prefix(actual_node,s):
    for children in actual_node.List_of_Children:
        if children.Value == s[0]:
            CP_2_Solve_Prefix(children,s[1:])
    return actual_node.Count - actual_node.Final


###################################################################################################################################

###################################################################################################################################

# Dado una lista de cadenas S definidas sobre el alfabeto ingl´es, determine si se cumple que para todo par
# ordenado (i, j), si no es prefijo de sj y sj no es prefijo de si
# . La complejidad temporal de su algoritmo debe
# ser O(sumatoria de |si|).

def CP_3_Solve(S: list[str]):
    root_trie = '^'
    for word in S:
        CP_2_Solve_Insert_with_COunt_Final(root_trie,word)

def CP_3_Solve_Prefix(actual_node):
    for children in actual_node.List_of_Children:
        if children.Count > 1:
            if children.Final >=1:
                return False
            
###################################################################################################################################

###################################################################################################################################

#  Dado una lista L de n enteros positivos y todos menores que 2^64. Dise˜ne un algoritmo que ordene la lista L en
# O(n).

def CP_4_Solve(L: list[int]):
    root_trie = '^'
    for number in L:
        Cp_1_Solve_Insert(root_trie,Binary_Mode(number))
    solution = []
    CP_4_Solve_List_Decimal_Mode(root_trie,[],solution)
    return solution

def CP_4_Solve_List_Decimal_Mode(actual_node,actual_number: list[int],solution):
    
    for children in actual_node.List_of_Children:
        actual_number.append(children.Value)
        CP_4_Solve_List_Decimal_Mode(children,actual_number,solution)

    solution.append(Decimal_Mode(actual_number))
    actual_number.clear
    return 

###################################################################################################################################

###################################################################################################################################

# Sea s una cadena sobre el alfabeto ingl´es, donde |s| = n. Dise˜ne un algoritmo que devuelva el n´umero de
# subcadenas distintas que contiene s en O(n^2).

def CP_5_Solve(s: str):
    root_trie = '^'
    for i in range(len(s)):
        Cp_1_Solve_Insert(root_trie,s[i:])
    return root_trie.Size

###################################################################################################################################

###################################################################################################################################

def CP_6_Solve_Build_Sorted_Trie(S : str,k : int):
    root_trie = '^'
    for i in range(len(S)):
        Cp_1_Solve_Insert(root_trie,S[i:]) #modificar insertar para que ordene la lista si crea un nuevo nodo ,sino crea nuevo nodo,proseguir
                                            #agregar count a cada nodo donde se actualice cada vez q pase por el.
    sol = CP_6_Solve(root_trie,k,0,'')
    if sol is None:
        return 'No existe solucion'
    else:
        return sol
        
def CP_6_Solve(actual_node,k : int,actual_count,actual_string : str):
    if actual_count >= k:
        return actual_string
    for children in actual_node.List_of_Children:
        CP_6_Solve(children,k,actual_count + children.Count,actual_string + children.Value) # este string no es por referencia
    