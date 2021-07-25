# 실행 화면
![6 1](https://user-images.githubusercontent.com/87646938/126897176-b40db132-f91f-44af-8e7d-8d3b224ddd60.jpg)
 - 초기 실행 화면

![6 2](https://user-images.githubusercontent.com/87646938/126897186-68174da0-6568-43d3-b943-bf9ae0399965.jpg)
 - 좌우 이동 및 점프를 하며 구름을 타고 올라가는 모습

![6 3](https://user-images.githubusercontent.com/87646938/126897197-14a511c6-7bfd-4cf7-a179-54ad529a6463.jpg)
 - 깃발(도착 지점)에 플레이어가 충돌하면 게임을 끝냄

![6 4](https://user-images.githubusercontent.com/87646938/126897209-6c5b984e-81c8-43b9-af57-c91c2cd597d3.jpg)
 - 깃발과 충돌하여 게임 오버 씬을 띄워주며, 화면을 탭 하면 초기 화면으로 돌아감

<center>
	
  ![6 1](https://user-images.githubusercontent.com/87646938/126897176-b40db132-f91f-44af-8e7d-8d3b224ddd60.jpg)       ![6 2](https://user-images.githubusercontent.com/87646938/126897186-68174da0-6568-43d3-b943-bf9ae0399965.jpg) 
  
  초기 실행 화면 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 좌우 이동 및 점프를 하며 구름을 타고 올라가는 모습<br>
  
  ![6 3](https://user-images.githubusercontent.com/87646938/126897197-14a511c6-7bfd-4cf7-a179-54ad529a6463.jpg)       ![6 4](https://user-images.githubusercontent.com/87646938/126897209-6c5b984e-81c8-43b9-af57-c91c2cd597d3.jpg) 
  
  깃발(도착 지점)에 플레이어가 충돌하면 게임을 끝냄 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 깃발과 충돌하면 게임 오버 씬을 띄워주며, 화면을 탭 하면 초기 화면으로 돌아감
</center>



# Week5_Unity

## Ch.6 Physics & Animation

### Climb Cloud

#### 6.1 게임 설계하기

##### 6.1.1 게임 기획

- 구름을 발판 삼아 깃발이 있는 정상까지 올라가는 게임



##### 6.1.2 게임 리소스

1. 화면에 놓일 오브젝트를 모두 나열
   - 플레이어, 깃발, 구름, 배경 이미지, 클리어 이미지
2. 컨트롤러 스크립트
   - 움직이는 오브젝트 : 플레이어 컨트롤러
3. 제너레이터 스크립트
   - 플레이할 때 생성되는 오브젝트 : X
4. 감독 스크립트
   - UI 갱신하거나 장면을 제어하는 감독 : 씬 전환용 감독
5. 스크립트 만드는 흐름
   - 컨트롤러 -> 제너레이터 -> 감독





#### 6.2 프로젝트&씬 만들기

##### 6.2.1 프로젝트 만들기

+ File -> New Project -> 2D -> (ClimbCloud)
  - 프로젝트에 리소스 추가
  -  실행할 때 화면 표시 설정
  -  Game탭 -> VSync 체크



##### 6.2.2 스마트폰용으로 설정

+ File -> Build Settings -> Platform 설정
+ 화면 크기 설정



##### 6.2.3 씬 저장하기

File -> Save As -> (GameScene)





#### 6.3 Physics로 움직임 제어하기

##### 6.3.1 Physics

+ ##### Physics : 유니티에 표준으로 속해 있는 물리 엔진

+  오브젝트를 간단하게 물리 동작에 맞춰 움직일 수 있다.

  - Rigidbody 컴포넌트 : 힘 계산
  - Collider 컴포넌트 : 물체의 충돌 판정



##### 6.3.2 Physics를 사용해서 플레이어 움직이기

- 플레이어 배치하고 Rigidbody 2D, Collider 2D 컴포넌트 적용하기

  - 플레이어 배치

    - (cat) 배치, POS(0, 0, 0)

    - Rigidbody 2D 적용
      - 플레이어가 중력에 따라 낙하
        (cat) -> Add Component -> Physics 2D -> Rigidbody 2D
    - Collider 2D 적용
      - (cat) -> Add Component -> Physics 2D -> Circle Collider 2D

- Collider 설정

  | **Circle Collider 2D**  | **원형 콜라이더**                                       |
  | ----------------------- | ------------------------------------------------------- |
  | **Box Collider 2D**     | **사각형 콜라이더**                                     |
  | **Edge Collider 2D**    | **선형 콜라이더, 오브젝트 일부를 충돌 판정할 때**       |
  | **Polygon Collider 2D** | **다각형 콜라이더, 오브젝트에 정확히 맞도록 충돌 판정** |



##### 6.3.3 발밑에 구름 배치하기

- (cloud) POS (0, -2, 0)



##### 6.3.4 구름에 Physics 적용하기

- (cloud) -> Add Component -> Physics 2D -> Box Collider 2D
- (cloud) -> Add Component -> Physics 2D -> Rigidbody 2D



##### 6.3.5 구름이 중력의 영향을 받지 않도록 설정하기

- 중력과 물리 연산의 영향을 무시하려면 Rigidbody 2D의 Body Type에서 Kinematic을 선택
  - (cloud) -> Rigidbody 2D 컴포넌트 -> Body Type -> Kinematic 





#### 6.4 콜라이더 모양 조정하기

##### 6.4.1 오브젝트에 잘 맞는 콜라이더의 모양

- 플레이어는 캡슐형 콜라이더를 사용하는 것이 수월

  - 사각형 콜라이더는 낮은 턱에 걸리거나, 좁은 틈새로 들어가기도 힘듦

    > Cappsule Collider 2D ... 원과 사각형을 조합



##### 6.4.2 플레이어의 콜라이더 모양 조정하기

- 원형 / (cat) -> Circle Collider 2D -> offset (0, -0,3), Radius (0.15)
- 사각형 / Add Component -> Physics 2D -> Box Collider 2D
  -  (cat) -> Box Collider 2D -> Size (0.3, 0.6)



​	**플레이어의 회전 방지**

- 넘어지지 않도록 Freeze Rotation 항목 설정 : 지정한 축의 회전을 방지
  - (cat) -> Rigidbody 2D -> Constraints -> Freeze Rotation의 Z 체크



##### 6.4.3 구름 콜라이더 조정하기

- (cloud) -> Box Collider 2D -> Size (1.4, 0.5)

- **Find 매서드**

  | Find 메서드                      | 설명                                              |
  | -------------------------------- | ------------------------------------------------- |
  | Find(Object)                     | 오브젝트 이름과 일치하는 게임 오브젝트 한 개 반환 |
  | FindWithTag(Tag_name)            | 태그 이름과 일치하는 게임 오브젝트 한 개 반환     |
  | FindGameObjectsWithTag(Tag_name) | 태그 이름과 일치하는 오브젝트 여러 개 반환        |
  | FindObjectOfType(Type_name)      | 타입 이름과 일치하는 오브젝트 한 개 반환          |
  | FindObjectsOfType(Type_name)     | 타입 이름과 일치하는 오브젝트 여러 개 반환        |





#### 6.5 입력에 맞춰 플레이어 움직이기

##### 6.5.1 스크립트를 사용해 플레이어 점프시키기

- 좌우 화살표로 이동, 스페이스바로 점프하는 컨트롤러 스크립트
  - Physics로 오브젝트에 직접 힘을 가해서 이동시킬 수 있다.
    - 좌표를 직접 변경하면 충돌 판정이 보증되지 않아, 오브젝트가 빠져나갈 수 있다.

1.  Scene 뷰에 오브젝트를 배치
2. 오브젝트를 움직이는 스크립트 작성
3. 작성한 스크립트를 오브젝트에 적용

```c#
(PlayerController)
public class PlayerController : MonoBehaviour
{
	Rigidbody2D rigid2D;
	float jumpForce = 680.0f;
	void Start()
	{
		this.rigid2D = GetComponent<Rigidbody2D>();
	}  // AddForce 매서드 사용하기 위해서 Rigidbody2D 컴포넌트 구하기
	void Update()
	{
 	// 점프
 	if (Input.GetKeyDown(KeyCode.Space))
 	{
 		this.rigid2D.AddForce(transform.up * this.jumpForce);
 	} // 길이 1의 위쪽 방향 벡터 * jumpForce 만큼 힘 가하기
}
```



##### 6.5.2 플레이어에 스크립트 적용

- (PlayerController) 를 (cat) 오브젝트로 드래그&드롭



##### 6.5.3 플레이어에 작용하는 중력 조절하기

- (cat) -> Rigidbody 2D -> Gravity Scale -> (3)



##### 6.5.4 플레이어를 좌우로 움직이기

```c#
(PlayerController)
public class PlayerController : MonoBehaviour
{
	...
	float walkForce = 30.0f;
	float maxWalkSpeed = 2.0f;
	...

	void Update()
	{
	...
	// 좌우 이동
	int key = 0;  // 아무것도 누르지 않았을 때 움직이지 않도록 key 변수 0
 	if (Input.GetKey(KeyCode.RightArrow)) key = 1;  // 오른쪽 시 key 변수 1
	if (Input.GetKey(KeyCode.LeftArrow)) key = -1;  // 왼쪽 시 key 변수 -1
	
	// 플레이어의 속도
	float speedx = Mathf.Abs(this.rigid2D.velocity.x);
	
	// 스피드 제한
	if (speedx < this.maxWalkSpeed)  // 최고속도 도달 시 가속 멈추기
	{
		this.rigid2D.AddForce(transform.right * key * this.walkForce);
	}  // 가속
	
	// 움직이는 방향에 따라 이미지 반전
    if (key != 0)
    {
    	transform.localScale = new Vector3(key, 1, 1);
    	// 스프라이트의 X축 방향 배율을 1 or -1 배로
    }
}
```



#### 6.6 애니메이션 만들기

##### 6.6.1 유니티 애니메이션

​	**스프라이트 애니메이션** : 움직임을 조금씩 변경한 스프라이트를 바꿔주는 방식



##### 6.6.2 메카님

​	**메카님** : 게임을 설계할 때 스프라이트 애니메이션을 작성해 각 애니메이션의 교체 시기를 지정할 수 있는데, 게임을 플레이할 때 메카님이 오브젝트 상태를 판단하고 자동으로 애니메이션으로 바꿔 재생할 수 있는 구조

- 스프라이트와 애니메이션 클립
  - 애니메이션 클립 : 애니메이션을 사용할 수 있도록 스프라이트를 정리한 파일
    - 재생할 스프라이트 정보, 재생 속도, 재생 시간 등 정보를 설정
- 애니메이션 클립과 애니메이터 컨트롤러
  - 애니메이터 컨트롤러 : 애니메이션 클립을 정리한 것
    - 어느 시점에 어느 애니메이션 클립을 재생할지 지정
- 애니메이터 컨트롤러와 Animator 컴포넌트
  - 오브젝트의 Animator 컴포넌트에 애니메이터 컨트롤러를 설정하면 정의한 애니메이션을 재생할 수 있다.



##### 6.6.3 애니메이션 클립 만들기

- 걷기 애니메이션
  1. 애니메이션 클립 파일 (Walk) 생성
  2. 애니메이터 컨트롤러 파일 (cat) 생성
  3. 애니메이터 컨트롤러 파일이 Animator 컨포턴트에 설정됨
  4. 플레이어에 Animator 컴포넌트가 적용
     - (cat) -> 도구 -> Window -> Animation -> Animation
     - Create -> (Walk) -> Save



##### 6.6.4 걷기 애니메이션 만들기

- 애니메이션을 시작한 후 몇 초 만에 어느 스프라이트를 표시할지 설정
  - Add Property -> Sprite Renderer -> Sprite -> +
  - 1초 뒤에 위치한 스프라이트를 del 로 제거
  - (cat_walk1), (cat_walk2), (cat_walk3) 드래그&드롭
  - 각각 0.07초, 0.14초, 0.21초로 각각 배치
  - 애니메이션 전체 길이를 0.28초 -> 0.28초 위에서 Add Keyframe



##### 6.6.5 애니메이션 속도 조절하기

- 이동 속도에 맞춰 애니메이션 재생 속도를 조절하는 것이 자연스럽다.

```c#
(PlayerController)
public class PlayerController : MonoBehaviour
{
    ...
	Animator animator;
	...
	void Start()
	{
		...
		this.animator = GetComponent<Animator>();
	}
	void Update()
	{
	...
	// 플레이어 속도에 맞춰 애니메이션 속도를 바꾸기
	this.animator.speed = speedx / 2.0f; //애니메이션 재생 속도가 플레이어 이동 속도에 비례하도록 수정
	}
}
```





#### 6.7 무대 만들기

##### 6.7.1 구름 프리팹 만들기

- 구름 발판을 복제해 무대를 만든다.
  - (cloud) 드래그&드롭 -> (cloudPrefab)



##### 6.7.2 구름 프리팹을 사용해 인스턴트 만들기

- (cloudPrefab)을 드래그&드롭



##### 6.7.3 깃발 세우기

- (flag) POS(0.9, 17.4, 0)



##### 6.7.4 배경 이미지 넣기

- (background) POS(0, 11, 0), Scale(2, 12, 1), Order in Layer (-1)





#### 6.8 플레이어 이동에 맞춰 카메라 움직이기

##### 6.8.1 카메라를 스크립트로 이동시키기

- 카메라 또한 오브젝트의 일종으로 컨트롤러 스크립트로 움직인다.



##### 6.8.2 카메라 스크립트 작성하기

```c#
(CameraController)
public class CameraController : MonoBehaviour
{
	GameObject player;
	void Start()
	{
        this.player = GameObejct.Find("cat");
    }
	void Update()
	{
		Vector3 playerPos = this.player.transform.position; //현재 플레이어의 위치
		transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        // 카메라의 y축을 playerPos.y 로 변경
	}
}
```



##### 6.8.3 카메라 스크립트 적용하기

- (CameraController)를 (Main Camera)에 적용





#### 6.9 Physics를 사용해 충돌 판정하기

##### 6.9.1 Physics로 충돌 판정하기

- 플레이어가 깃발에 닿으면 클리어 씬으로 전환되도록 충돌 판정을 구현

  - Physics를 사용한 충돌 판정 방법을 사용

    - Physics를 사용한 판정 종류
      \+	Collision 모드 : 닿았을 때, 충돌했을 때 주변에 미치는 영향까지 포함해 반응
      \+	Trigger 모드 : 충돌 판정만 하고 충돌 응답은 실행하지 않음

    - |                  | Collision 모드     | Trigger 모드     |
      | ---------------- | ------------------ | ---------------- |
      | 충돌한 순간      | OnCollisionEnter2D | OnTriggerEnter2D |
      | 충돌 중          | OnCollisionStay2D  | OnTriggerStay2D  |
      | 충돌이 끝난 순간 | OnCollisionExit2D  | OnTriggerExit2D  |



##### 6.9.2 플레이어와 깃발의 충돌 판정 구현하기

- Physics의 충돌 판정 조건

  - 판정할 모든 오브젝트에 Collider 컴포넌트가 적용되어 있어야 함

  - 충돌을 판정할 오브젝트 중 적어도 한쪽엔 Rigidbody 컴포넌트 적용되있어야 함

    1. 깃발에 Collider2D 컴포넌트 적용, Trigger 모드로 설정
    2. 플레이어와 깃발이 닿았을 때 OnTriggerEnter2D 매서드 PlayerController로 구현

    - 깃발에 Collider 컴포넌트 적용

      - (flag) -> Add Component -> Physics 2D -> Box Collider 2D	

      - is Trigger 체크

      - ```c#
        (PlayerController)
        ...
         // 깃발에 도착
         void OnTriggerEnter2D(Collider2D other)
         { Debug.Log("골"); }
        }
        ```



#### 6.10 씬 전환하기

##### 6.10.1 씬 전환

- 유니티에서는 게임 화면을 묶어 씬 형태로 관리
  - 전환할 시점에 다른 씬의 파일명을 지정하기만 하면 됨



##### 6.10.2 클리어 씬 만들기

- File -> New Scene -> Save As -> (ClearScene) -> Save
- (background_clear) POS(0, 0, 0)



##### 6.10.3 클리어 씬에서 게임 씬으로 전환하기

- 감독 만들기

  1. 감독 스크립트 작성

  2. 빈 오브젝트 만들기

  3. 빈 오브젝트에 감독 스크립트 적용

     - 감독 스크립트 작성

     - ```c#
       (ClearDirector)
       using UnityEngine.SceneManagement;  // LoadScene을 사용하는데 필요
       public class ClearDirector : MonoBehaviour
       {
       	void Update()
       	{
        		if (Input.GetMouseButtonDown(0))
        		{ SceneManager.LoadScene("GameScene"); }  // 게임 씬으로 전환
       	}
       }
       ```

       > LoadScene : 매개변수로 받은 씬 이름의 씬을 로드

     - 빈 오브젝트 생성

       - Hierarchy -> + -> Create Empty -> (ClearDirector)

     - 감독 스크립트 적용

       - (ClearDirector)를 (ClearDirector)로 드래그&드롭

     > 유니티에 씬을 등록하지 않았기 때문에 오류 발생. 어느 씬을 어떤 순서로 사용하는지 등록해야 할 필요 있음



##### 6.10.4 씬 등록하기

- File -> Build Settings -> (ClearScene)(GameScene)를 Scenese In Build로 드래그&드롭
- 0번 씬부터 시작하기 때문에 (GameScene 0), (ClearScene 1)이 되도록 나열



##### 6.10.5 게임 씬에서 클리어 씬으로 전환하기

- 플레이어가 깃발에 닿는 시점에 씬 전환 스크립트를 실행

- ```c#
  (PlayerController)
  using UnityEngine.SceneManagement;
  	...
  	void OnTriggerEnter2D(Collider2D other)
  	{ SceneManager.LoadScene("ClearScene"); }
  }
  ```



##### 6.10.6 버그 없애기

- 점프하는 도중에도 계속 점프

  - 플레이어가 점프 중인지 감지하여 점프 중일 때는 힘이 미치지 않도록 설정

  - (PlayerController)의 점프 처리를 y축 방향 속도가 0일 때만 점프한다로 구현

     ```c#
     (PlayerController)
      if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
      { ... }
     ```

    

- 화면 밖으로 나가도 끝없이 떨어짐

  - 플레이어의 y 좌표가 -10 미만이면 씬의 처음으로 돌아가도록 설정

    ```c#
     (PlayerController)
     if (transform.position.y < -10)
     { SceneManager.LoadScene("GameScene"); }
    ```

    

- 기기 사이의 속도 차 없애기

  - 고성능 PC와 저성능 기기에서의 Update 매서드가 1초에 호출되는 수가 다르다.
  - 따라서 이동 속도에 Time.deltaTime을 곱하면, 어떤 기기에서든 1초 후에 자리하는 지점이 같게 만들 수 있다.





#### 6.11 스마트폰에서 움직여 보기

##### 6.11.1 스마트폰 조작에 대응시키기

- 스마트폰의 기울기는 가속도 센서로 구할 수 있다.

  - 좌우로 기울이면 X축 값이 -1.0 부터 1.0까지 범위로 변한다.

  - 일정 값보다 크면 플레이어가 좌우로 이동하도록 PlayerController 스크립트 추가

    ```c#
    (PlayerController)
    public class PlayerController : MonoBehaviour
    {
    ...
    float threshold = 0.2f;  // 기울기 최소값
    ...
    void Update()
    {
     // 점프 - 화면을 탭 하면
     if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
     { ... }
     // 좌우 이동 - 가속도 센서의 x 값이 theshold 이상, 이하일 때
     if (Input.acceleration.x > this.threshold) key == 1;
     if (Input.acceleration.x < -this.threshold) key == -1;
    ...
    }
    ```

    

##### 6.11.2 점프 애니메이션

- 점프 예비 동작은 프레임을 빠르게 바꾸기

  - 걷기 애니메이션처럼 반복해서 재생하지는 않는다
    - (cat) -> Window -> Animation -> Animation
    - Create New Clip -> (Jump) -> Save
    - Add Property -> Sprite Renderer -> Sprite -> 1.0초의 스프라이트 제거
    - (cat_jump1 0.05초), (cat_jump2 0.1초), (cat_jump3 0.2초)
    - 0.3초 부분에 Add Keyframe
    - 반복 재생이 필요없기 때문에 Loop Time 체크 해제

- 애니메이션 전환 설정

  - Walk <-> Jump 관계를 애니메이터 컨트롤러에서 설정

    - (cat)을 더블클릭하여 Animator 창 열기

    | 전환 설정 |                                                              |
    | --------- | ------------------------------------------------------------ |
    | Entry     | 애니메이션을 시작할 때 Enty 노드로 전환                      |
    | Any State | 현재 상태에 관계없이 특정 애니메이션으로 전환하고자 할 때 사용 |
    | Exit      | 애니메이션을 종료하고자 할 때 Exit 노드로 전환               |

    

  -  Walk에서 Jump로 전환할 수 있도록 만들기 

    - Walk 노드를 마우스 오른쪽 버튼 -> Make Transition -> Jump 클릭
    - Jump 노드를 마우스 오른쪽 버튼 -> Make Transition -> Walk 클릭

- 전환 시점 설정

  - Jump에서 Walk로 향하는 전환 화살표 클릭 -> Has Exit Time 체크 -> Settings -> Exit Time 1 -> Transition Duration / Transition Offset 0

    | 전환 시점 설정      |                                                        |
    | ------------------- | ------------------------------------------------------ |
    | Has Exit Time       | 애니메이션 종료 시 자동으로 애니메이션 전환 여부       |
    | Exit Time           | 애니메이션 종료 시간을 정규화 시간(0.0 ~ 1.0)으로 설정 |
    | Transition Duration | 애니메이션 전환 시간을 정규화 시간으로 설정            |
    | Transition Offset   | 애니메이션 재생 시간을 정규화 시간으로 설정            |

    

  - Walk에서 Jump로 전환하는 시점을 지정

    - 점프 버튼이 눌린 시점에 전환할 수 있도록 전환 화살표 Trigger 설치

      > Trigger : 점프 버튼이 눌린 시점에 Trigger를 열어 Walk에서 Jump로 전환

    - Animator창 -> Parameters -> + -> Trigger -> (JumpTrigger)

  - Trigger 전환 화살표에 배치

    - Walk에서 Jump로 향하는 전환 화살표 클릭 -> Conditions -> + -> JumpTrigger

    

  - 점프 버튼을 누를 때 적용할 점프 트리거 스크립트

    ```c#
    (PlayerController)
    ...
    void Update()
    {
     // 점프
     if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
     {
      this.animator.SetTrigger("JumpTrigger");
      this.rigid2D.AddForce(transform.up * this.jumpForce);
     }
     ...
     // 플레이어의 속도에 맞춰서 애니메이션 속도 바꾸기
     if (this.rigid2D.velocity.y == 0)
     { this.animator.speed = speedx / 2.0f; }
     else
     { this.animator.speed = 1.0f; }
     ...
    }
    ```

    

> SetTrigger : 점프 트리거를 열 때 필요한 매서드
>
> 매개변수로 지정한 이름의 트리거를 열어 애니메이션을 전환시키는 역할
>
> 점프 중이면 항상 애니메이션 속도를 1.0으로 하고, 아니면 이동속도에 따라 애니메이션이 재생되도록 한다. 
